using Lobster.API.Entities;
using Lobster.API.Repositories;
using Lobster.API.Models;
using Lobster.API.Services;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lobster.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : ControllerBase
    {
        private IStoryService _storyService;
        private readonly ILogger<StoryController> _logger;

        public StoryController(IStoryService storyService, ILogger<StoryController> logger)
        {
            _storyService = storyService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(Story), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Story>> GetStory()
        {
            var story = await _storyService.GetStory(1);
            return Ok(story);
        }

        [HttpGet("gethistory")]
        [Authorize]
        [ProducesResponseType(typeof(Story), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserHistory>>> GetHistory()
        {
            var user = (User)HttpContext.Items["User"];
            var lstHistory = await _storyService.GetUserHistory(user.Id);
            _logger.LogInformation($"Getting history for user {user.Username}");
            return Ok(lstHistory);
        }

        // POST Story/createhistory
        [HttpPost("createhistory")]
        [Authorize]
        public async Task<ActionResult> CreateHistory([FromBody] UserHistory hist)
        {
            var user = (User)HttpContext.Items["User"];
            hist.UserId = user.Id;
            await _storyService.CreateHistory(hist);
            return Ok();
        }
    }
}
