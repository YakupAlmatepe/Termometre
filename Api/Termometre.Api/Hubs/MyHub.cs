using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Termometre.Api.Hubs
{
    public class MyHub : Hub
    {
        //clientlere bilgi aktarımı fonksiyonu
        public async Task SendMessageAsync(string message)
        {

            await Clients.All.SendAsync("receiveMessage",message);
            //if (Clients.All != null)
            //{
            //    await Clients.All.SendAsync("receiveMessage", message);
            //}
        }
    }
}
