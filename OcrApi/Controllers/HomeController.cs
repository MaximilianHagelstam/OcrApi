using Microsoft.AspNetCore.Mvc;
using OcrApi.Models;

namespace OcrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Health> HealthCheck()
        {
            return Ok(new Health(true));
        }
    }
}
