using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Termometre.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        private readonly ApplicationContext _context;

        public ValuesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getDataFromAPI")]
        public IActionResult GetDatFromDatabase()
        {

            List<RandomTemperature> data = _context.RandomTempretures.ToList();
            return Ok(data);
            //return Ok("selam");
        }
    }
}
