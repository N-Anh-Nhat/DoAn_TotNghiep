﻿using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetUserById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetUserByID(Id));
        }
        [HttpPost("InsertUser")]

        public async Task<IActionResult> InsertUser(User users, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertUser(users, user));
        }
        //[HttpPost("DeleteUser")]

        //public async Task<IActionResult> DeleteUser(User users, string user)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    return Ok(await dbContext.DeleteUser(users, user));
        //}
    }
}