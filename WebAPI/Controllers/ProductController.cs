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
    public class ProductController : Controller
    {
        private readonly IProduct dbContext;

        public ProductController(IProduct dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetProduct());
        }
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetProductByID(Id));
        }
        [HttpPost("InsertProduct")]

        public async Task<IActionResult> InsertProduct(Product Product, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertProduct(Product, user));
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product Product,string user )  
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateProduct(Product, user));
        }
    }
}
