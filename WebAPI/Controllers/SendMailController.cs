using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services.Interface;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]
    public class SendMailController : Controller
    {

        private readonly ISendMailServices dbContext;

        public SendMailController(ISendMailServices dbcontext) => this.dbContext = dbcontext;

        [HttpPost("SendMailS")]

        public async Task<IActionResult> SendMailS(MailContent Order, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.SendMail(Order));
        }
       
    }
}
