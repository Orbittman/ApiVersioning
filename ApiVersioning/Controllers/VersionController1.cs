using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/version")]
    [ApiController]
    public class Version1Controller : ControllerBase
    {
        [HttpGet("test-method-1")]
        public ActionResult<string> Get_1_0() => "test-method-1 Version 1.1";
    }
}
