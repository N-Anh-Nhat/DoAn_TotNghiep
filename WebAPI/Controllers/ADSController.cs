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
    public class ADSController : Controller
    {
        private readonly IADS dbContext;

        public ADSController(IADS dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetADS")]
        public async Task<IActionResult> GetADS()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetADS());
        }
        [HttpGet("GetADSById")]
        public async Task<IActionResult> GetADSById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetADSByID(Id));
        }
        [HttpPost("InsertADS")]

        public async Task<IActionResult> InsertADS(ADS ads, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertADS(ads, user));
        }
        [HttpPost("DeleteADS")]

        public async Task<IActionResult> DeleteADS(ADS ads, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteADS(ads, user));
        }
    }
}
