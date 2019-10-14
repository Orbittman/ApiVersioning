using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/version")]
    [ApiController]
    public class Version2Controller : Version1Controller
    {
        [HttpGet("test-method-2")]
        public ActionResult<string> Get_2_0() => "test-method-2 Version 2.0";
    }
}
