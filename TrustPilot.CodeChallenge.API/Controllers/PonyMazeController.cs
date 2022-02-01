using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrustPilot.CodeChallenge.API.Models;

namespace TrustPilot.CodeChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PonyMazeController : ControllerBase
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PonyMazeController> _logger;

        public PonyMazeController(IHttpClientFactory httpClientFactory,
            ILogger<PonyMazeController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        // [ProducesResponseType(typeof(MediaTypeNames.Application.Json), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMaze()
        {
            _logger.LogInformation($"Calling Create Maze End-Point...");

            var httpClient = _httpClientFactory.CreateClient(Constants.HttpClientConstants.HttpClientName);

            var mazeDimentions = new Constants.MazeDimensions();

            var mazeOptions = new CreateMazeModel
            {
                MazeHeight = mazeDimentions.Height,
                MazeWidth = mazeDimentions.Width,
                PlayerName = "Twilight Sparkle",
                Difficulty = 0
            };

            var objectToSend = JsonConvert.SerializeObject(mazeOptions);

            var response = await httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri("https://ponychallenge.trustpilot.com/pony-challenge/maze"),
                Method = HttpMethod.Post,
                Content = new StringContent(objectToSend, Encoding.UTF8, MediaTypeNames.Application.Json)
            });

            response.EnsureSuccessStatusCode();

            return Ok();
        }
    }
}
