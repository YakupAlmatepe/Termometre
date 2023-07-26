using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Termometre.Api.Hubs
{
    //    public class MyHub : Hub
    //    {
    //        //clientlere bilgi aktarımı fonksiyonu
    //        public async Task SendMessageAsync(string message)
    //        {

    //            await Clients.All.SendAsync("receiveMessage",message);
    //            //if (Clients.All != null)
    //            //{
    //            //    await Clients.All.SendAsync("receiveMessage", message);
    //            //}
    //        }
    //    }
    //}


    public class MyHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Connected", Context.ConnectionId);
        }

        public async Task SendMessage(string message)
        {
            try
            {
                await Clients.All.SendAsync("ReceiveMessage", message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}