using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetCategory());
        }
    }
}
