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
            return Ok(await ApiHelper.GetFplFromFlight(callSign));
        }
    }
}