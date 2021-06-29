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
    public class RoleController : Controller
    {
        private readonly IRole dbContext;

        public RoleController(IRole dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetRole")]
        public async Task<IActionResult> GetRole()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetRole());
        }
        [HttpGet("GetRoleById")]
        public async Task<IActionResult> GetRoleById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetRoleByID(Id));
        }
        [HttpPost("InsertRole")]

        public async Task<IActionResult> InsertRole(Role role, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertRole(role, user));
        }
        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole(Role role, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteRole(role, user));
        }
        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(Role role, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateRole(role, user));
        }
    }
}
