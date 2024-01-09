using Microsoft.AspNetCore.SignalR;

namespace Shop.Models.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Clients.All.SendAsync("ReceiveMessage", user, message);

        }

    }
}
