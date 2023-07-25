using Microsoft.AspNetCore.SignalR;

namespace Termometre.Api.Hubs
{
    public class MyHub : Hub
    {
        //clientlere bilgi aktarımı fonksiyonu
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
