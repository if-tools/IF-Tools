using System.Threading.Tasks;
using IFTools.Data;
using Microsoft.AspNetCore.Mvc;

namespace IFTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfApiController : Controller
    {
        [HttpGet("[action]")]
        public async Task<ActionResult> GetFlightFpl(string callSign)
        {
            if (Request.Host.Host != "localhost") return BadRequest("Not authorized.");

            return Ok(await ApiHelper.GetFplFromFlight(callSign));
        }
    }
}