using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Termometre.Api.Hubs;

namespace Termometre.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //MyBusiness'ı enjekte etmeliyim

        readonly IHubContext<MyHub> _hubContext;
        readonly MyHub _myHub;

      
        public HomeController(IHubContext<MyHub> hubContext, MyHub myHub)
        {
            _hubContext = hubContext;
            _myHub = myHub;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myHub.SendMessageAsync(message);
            return Ok();

            //
        }


    }
}
