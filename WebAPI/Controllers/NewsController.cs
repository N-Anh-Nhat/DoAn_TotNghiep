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
    public class NewsController : Controller
    {
        private readonly INews dbContext;

        public NewsController(INews dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetNews")]
        public async Task<IActionResult> GetNews()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetNews());
        }
        [HttpGet("GetNewsById")]
        public async Task<IActionResult> GetNewsById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetNewsByID(Id));
        }
        [HttpPost("InsertNews")]

        public async Task<IActionResult> InsertNews(News news, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertNews(news, user));
        }
        [HttpPost("DeleteNews")]

        public async Task<IActionResult> DeleteNews(News news, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteNews(news, user));
        }
    }
}

