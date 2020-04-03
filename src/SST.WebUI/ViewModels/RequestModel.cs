namespace SST.WebUI.ViewModels
{
    public class RequestModel
    {
        public Application.Requests.Queries.GetNotApprovedRequests.RequestsListVm NotApprovedRequestsList { get; set; }

        public Application.Requests.Queries.GetRequests.RequestsListVm AllRequestsList { get; set; }
    }
}
