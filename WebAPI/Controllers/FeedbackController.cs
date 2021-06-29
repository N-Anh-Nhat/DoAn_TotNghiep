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
        public async Task<IActionResult> GetFeedback()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetFeedback());
        }
        [HttpGet("GetFeedbackById")]
        public async Task<IActionResult> GetFeedbackById(string Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.GetFeedbackByID(Id));
        }
        [HttpPost("InsertFeedback")]

        public async Task<IActionResult> InsertFeedback(Feedback Feedback, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.InsertFeedback(Feedback, user));
        }
        [HttpPost("DeleteFeedback")]

        public async Task<IActionResult> DeleteFeedback(Feedback Feedback, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.DeleteFeedback(Feedback, user));
        }
        [HttpPost("UpdateFeedback")]
        public async Task<IActionResult> UpdateFeedback(Feedback feedback, string user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await dbContext.UpdateFeedback(feedback, user));
        }
    }
}
