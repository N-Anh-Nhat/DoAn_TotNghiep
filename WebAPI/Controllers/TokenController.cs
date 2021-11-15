using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        
        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("GetOk")]

        public IActionResult GetOk()
        {
            return Ok("Ok");
        }

        [HttpGet("GetToken")]
        public IActionResult GetToken([FromQuery] string u, [FromQuery] string p, [FromQuery] string account)
        {
            string accessToken = "Bearer ";

            int expiresTime = _config.GetValue<int>("AuthorizeSettings:expires");
            
            if (CheckLogin(u,p))
            {
                accessToken += LIB.Common.Utils.GenerateJsonWebToken(account, _config, expiresTime);
            }

            return Ok(accessToken);
        }

        [HttpGet("CheckToken")]
        [Authorize]
        public IActionResult CheckToken()
        {
            return Ok(1);
        }

        [NonAction]
        public bool CheckLogin(string name, string pw)
        {
            var accessName = _config.GetValue<string>("AuthorizeSettings:username");
            var accessPass = _config.GetValue<string>("AuthorizeSettings:password");

            if (name == accessName && pw == accessPass)
                return true;
            return false;
        }
    }
}
