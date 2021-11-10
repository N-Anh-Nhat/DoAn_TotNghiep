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
    public class OrderController : Controller
    {
        private readonly IOrder dbContext;

        public OrderController(IOrder dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetOrder());
        }
        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetOrderByID(Id));
        }
        [HttpPost("InsertOrder")]

        public async Task<IActionResult> InsertOrder(Orders Order, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertOrder(Order, user));
        }
        [HttpPost("DeleteOrder")]

        public async Task<IActionResult> DeleteOrder(Orders Order, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteOrder(Order, user));
        }
        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(Orders Order, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateOrder(Order, user));
        }
        [HttpGet("ReportOrder")]
        public async Task<IActionResult> ReportOrder(int pYear, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.ReportOrder(pYear, user));
        }
    }
}
