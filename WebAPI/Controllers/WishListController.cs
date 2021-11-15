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
    public class WishListController : Controller
    {
        private readonly IWishList dbContext;

        public WishListController(IWishList dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetWishList")]
        [Authorize]
        public async Task<IActionResult> GetWishList()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetWishList());
        }
        [HttpGet("GetWishListById")]
        [Authorize]
        public async Task<IActionResult> GetWishListById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetWishListByID(Id));
        }
        [HttpPost("InsertWishList")]
        [Authorize]
        public async Task<IActionResult> InsertWishList(WishList wishlist, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertWishList(wishlist, user));
        }

        [HttpPost("UpdateWishList")]
        [Authorize]
        public async Task<IActionResult> UpdateWishList(WishList users, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateWishList(users, user));
        }
        [HttpPost("DeleteWishList")]
        [Authorize]
        public async Task<IActionResult> DeleteWishList(WishList wishlist, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteWishList(wishlist, user));
        }
    }
}
