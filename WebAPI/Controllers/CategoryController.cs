using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetCategory()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetCategory());
        }
        [HttpGet("GetCategoryById")]
        [Authorize]
        public async Task<IActionResult> GetCategoryById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetCategoryByID(Id));
        }
        [HttpPost("InsertCategory")]
        [Authorize]

        public async Task<IActionResult> InsertCategory(Category category, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertCategory(category, user));
        }
        [HttpPost("DeleteCategory")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(Category category, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteCategory(category, user));
        }
        [HttpPost("UpdateCategory")]
        [Authorize]
        public async Task<IActionResult> UpdateCategory(Category category, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateCategory(category, user));
        }
    }
}
