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
    public class Order_DetailController : Controller
    {
        private readonly IOder_detail dbContext;

        public Order_DetailController(IOder_detail dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetOrder_Detail")]
        public async Task<IActionResult> GetOrder_Detail()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetOrder_Detail());
        }
        [HttpGet("GetOrder_DetailById")]
        public async Task<IActionResult> GetOrder_DetailById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetOrder_DetailByID(Id));
        }
        [HttpPost("InsertOrder_Detail")]

        public async Task<IActionResult> InsertOrder_Detail(Order_Detail Order_Detail, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertOrder_Detail(Order_Detail, user));
        }
        [HttpPost("DeleteOrder_Detail")]

        public async Task<IActionResult> DeleteOrder_Detail(Order_Detail Order_Detail, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteOrder_Detail(Order_Detail, user));
        }
    }
}
