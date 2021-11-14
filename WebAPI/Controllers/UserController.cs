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
    public class UserController : Controller
    {
        private readonly IUser dbContext;

        public UserController(IUser dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetUser());
        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetUserByID(Id));
        }
        [HttpPost("InsertsUser")]

        public async Task<IActionResult> InsertsUser(User data, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertUser(data, user));
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User users, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateUser(users, user));
        }
        //Login
        [HttpGet("GetCheckLogin")]
        public async Task<IActionResult> GetCheckLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username)) ModelState.AddModelError("Username", "Username is required");

            if (string.IsNullOrEmpty(password)) ModelState.AddModelError("PassWord", "PassWord is required");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var rs = await dbContext.CheckLogin(username, password);

            return Ok(rs);
        }
    }
}
