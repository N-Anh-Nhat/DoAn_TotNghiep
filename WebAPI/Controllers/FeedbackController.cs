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
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedback dbContext;

        public FeedbackController(IFeedback dbcontext) => this.dbContext = dbcontext;

        [HttpGet("GetFeedback")]
        [Authorize]
        public async Task<IActionResult> GetFeedback()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetFeedback());
        }
        [HttpGet("GetFeedbackById")]
        [Authorize]
        public async Task<IActionResult> GetFeedbackById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetFeedbackByID(Id));
        }
        [HttpPost("InsertsFeedback")]
        [Authorize]

        public async Task<IActionResult> InsertsFeedback(Feedback data, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertFeedback(data, user));
        }
        [HttpPost("DeleteFeedback")]
        [Authorize]

        public async Task<IActionResult> DeleteFeedback(Feedback Feedback, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteFeedback(Feedback, user));
        }
        [HttpPost("UpdateFeedback")]
        [Authorize]
        public async Task<IActionResult> UpdateFeedback(Feedback feedback, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateFeedback(feedback, user));
        }
    }
}
