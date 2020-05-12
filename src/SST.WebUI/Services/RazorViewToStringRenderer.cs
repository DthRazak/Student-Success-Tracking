using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace SST.WebUI.Services.RazorToStringExample
{
    /// <summary>
    /// Render a ASP.NET Core Razor view to a string.
    /// Can run from a console app, doesn't need an HttpContext.
    /// Adapted and fixed version from:
    /// https://github.com/aspnet/Entropy/blob/93ee2cf54eb700c4bf8ad3251f627c8f1a07fb17/samples/Mvc.RenderViewToString/RazorViewToStringRenderer.cs.
    /// </summary>
    public class RazorViewToStringRenderer
    {
        private readonly IRazorViewEngine viewEngine;
        private readonly ITempDataProvider tempDataProvider;
        private readonly IServiceProvider serviceProvider;

        public RazorViewToStringRenderer(
            IRazorViewEngine viewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            this.viewEngine = viewEngine;
            this.tempDataProvider = tempDataProvider;
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Render a view and model, and return the output as a string.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="viewName">The view to render, with any directories and without the extension. e.g. Home/Index.</param>
        /// <param name="model">The model object.</param>
        /// <returns>The string output of the view; typically html.</returns>
        public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
        {
            var actionContext = GetActionContext();
            var view = FindView(actionContext, viewName);

            using (var output = new StringWriter())
            {
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    new ViewDataDictionary<TModel>(
                        metadataProvider: new EmptyModelMetadataProvider(),
                        modelState: new ModelStateDictionary()
                    )
                    {
                        Model = model
                    },
                    new TempDataDictionary(
                        context: actionContext.HttpContext,
                        provider: tempDataProvider
                    ),
                    output,
                    new HtmlHelperOptions());

                await view.RenderAsync(viewContext).ConfigureAwait(false);

                return output.ToString();
            }
        }

        private IView FindView(ActionContext actionContext, string viewName)
        {
            var getViewResult = viewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: true);
            if (getViewResult.Success)
            {
                return getViewResult.View;
            }

            var findViewResult = viewEngine.FindView(actionContext, viewName, isMainPage: true);
            if (findViewResult.Success)
            {
                return findViewResult.View;
            }

            // nothing found, return an error
            var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
            var errorLines =
                new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }
                .Concat(searchedLocations);

            throw new InvalidOperationException(string.Join(Environment.NewLine, errorLines));
        }

        private ActionContext GetActionContext()
        {
            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            MapRoutes(actionContext);

            return actionContext;
        }

        private void MapRoutes(ActionContext actionContext)
        {
            var routes = new RouteBuilder(new ApplicationBuilder(serviceProvider))
            {
                DefaultHandler = new DefaultHandler()
            };
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"
            );
            actionContext.RouteData.Routers.Add(routes.Build());
        }

        /// <summary>
        /// Not actually used, but needed to get past the validation checks in routes.MapRoute.
        /// </summary>
        private class DefaultHandler : IRouter
        {
            public VirtualPathData GetVirtualPath(VirtualPathContext context) => null;

            public Task RouteAsync(RouteContext context) => Task.CompletedTask;
        }
    }
}
