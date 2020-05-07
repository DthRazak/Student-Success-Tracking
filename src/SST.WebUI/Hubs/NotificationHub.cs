using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SST.WebUI.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task NotifySudent(string user, string subject, int mark)
        {
            var message = $"{subject}. You get {mark}.";

            await Clients.User(user).SendAsync("ReceiveMessage", message);
        }
    }
}
