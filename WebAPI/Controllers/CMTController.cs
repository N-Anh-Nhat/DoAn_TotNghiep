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
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]
    public class CMTController : ControllerBase
    {
        private readonly ICMT dbContext;

        public CMTController(ICMT dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetCMT")]
        public async Task<IActionResult> GetCMT()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetCMT());
        }
        [HttpGet("GetCMTById")]
        public async Task<IActionResult> GetCMTById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetCMTByID(Id));
        }
        [HttpPost("InsertCMT")]

        public async Task<IActionResult> InsertCMT(CMT CMT, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertCMT(CMT, user));
        }
        [HttpPost("DeleteCMT")]

        public async Task<IActionResult> DeleteCMT(CMT CMT, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteCMT(CMT, user));
        }
        [HttpPost("UpdateCMT")]
        public async Task<IActionResult> UpdateCMT(CMT cmt, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateCMT(cmt, user));
        }
    }
}
