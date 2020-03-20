using Autofac;
using MediatR;
using System.Reflection;

namespace SST.Application
{
    public class DependencyModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(
                typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(typeof().GetTypeInfo().Assembly)
        }
    }
}
