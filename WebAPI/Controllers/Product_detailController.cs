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
    public class Product_detailController : Controller
    {
        private readonly IProduct_detail dbContext;

        public Product_detailController(IProduct_detail dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetProduct_detail")]
        public async Task<IActionResult> GetProduct_detail()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetProduct_Detail());
        }
        [HttpGet("GetProduct_detailById")]
        public async Task<IActionResult> GetProduct_detailById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetProduct_DetailByID(Id));
        }
        [HttpPost("InsertProduct_detail")]

        public async Task<IActionResult> InsertProduct_detail(Product_Detail Product_detail, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertProduct_Detail(Product_detail, user));
        }

        [HttpPost("UpdateProduct_detail")]
        public async Task<IActionResult> UpdateProduct_detail(Product_Detail product_Detail, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateProduct_Detail(product_Detail, user));
        }
    }
}
