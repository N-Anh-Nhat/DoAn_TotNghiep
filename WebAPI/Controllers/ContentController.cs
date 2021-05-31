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
    public class ContentController : Controller
    {
        private readonly IContent dbContext;

        public ContentController(IContent dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetContent")]
        public async Task<IActionResult> GetContent()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetContent());
        }
        [HttpGet("GetContentById")]
        public async Task<IActionResult> GetContentById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetContentByID(Id));
        }
        [HttpPost("InsertContent")]

        public async Task<IActionResult> InsertContent(Content content, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertContent(content, user));
        }
        [HttpPost("DeleteContent")]

        public async Task<IActionResult> DeleteContent(Content content, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteContent(content, user));
        }
    }
}
