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

namespace Lobster.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : ControllerBase
    {
        private IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(Story), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Story>> GetStory()
        {
            var story = await _storyService.GetStory(1);
            return Ok(story);
        }

    }
}
