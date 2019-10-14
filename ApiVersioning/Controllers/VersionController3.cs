using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/version")]
    [ApiController]
    public class Version3Controller : ControllerBase
    {
        [HttpGet("test-method-3")]
        public ActionResult<string> Get_1_0() => "test-method-3 Version 1.0";

        [ApiVersion("3.0")]
        [HttpGet("test-method-4")]
        public ActionResult<string> Get_4_0() => "test-method-4 Version 3.0";
    }
}
