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
    public class CategoryController : Controller
    {
        private readonly ICategory dbContext;

        public CategoryController(ICategory dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetCategory());
        }
        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetCategoryByID(Id));
        }
        [HttpPost("InsertCategory")]

        public async Task<IActionResult> InsertCategory(Category category, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertCategory(category, user));
        }
    }
}
