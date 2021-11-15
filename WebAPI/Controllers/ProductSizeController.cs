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
    public class ProductSizeController : Controller
    {
        private readonly IProductSize dbContext;

        public ProductSizeController(IProductSize dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetProductSize")]
        [Authorize]
        public async Task<IActionResult> GetProductSize()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetProductSize());
        }
        [HttpGet("GetProductSizeById")]
        [Authorize]
        public async Task<IActionResult> GetProductSizeById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetProductSizeByID(Id));
        }
        [HttpPost("InsertProductSize")]
        [Authorize]

        public async Task<IActionResult> InsertProductSize(ProductSize ProductSize, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertProductSize(ProductSize, user));
        }

        [HttpPost("UpdateProductSize")]
        [Authorize]
        public async Task<IActionResult> UpdateProductSize(ProductSize ProductSize, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateProductSize(ProductSize, user));
        }
        [HttpPost("UpdateListProductSize")]
        [Authorize]
        public async Task<IActionResult> UpdateListProductSize(List<ProductSize> data, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateListProductSize(data, user));
        }
    }
}
