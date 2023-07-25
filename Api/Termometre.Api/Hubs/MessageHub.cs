using Microsoft.AspNetCore.SignalR;

namespace Termometre.Api.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            Clients.All.SendAsync("receiveMessage", message);
        }

    }
}
