using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using TrustPilot.CodeChallenge.Models;
using TrustPilot.CodeChallenge.Models.Enums;
using TrustPilot.CodeChallenge.Services.Interfaces;

namespace TrustPilot.CodeChallenge.API.Controllers.V1
{
    /// <summary>
    /// Api Controller for Pony (P) in a maze that user is trying to escape it
    /// from Domokun (D) and help it to reach the end-point (E)
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PonyMazeController : ControllerBase
    {
        #region Private Members

        private readonly IMazeManager _mazeManager;
        private readonly ILogger<PonyMazeController> _logger;

        #endregion

        #region Ctor

        /// <summary>
        /// Constrcutor of the Pony Maze Controller
        /// </summary>
        /// <param name="mazeManager"></param>
        /// <param name="logger"></param>
        public PonyMazeController(IMazeManager mazeManager, ILogger<PonyMazeController> logger)
        {
            _mazeManager = mazeManager;
            _logger = logger;
        }

        #endregion

        #region End-Points (APIs)

        /// <summary>
        /// This end-point is for creating a maze with dimention between 15 and 25
        /// With a valid Pony Name <see href="https://github.com/csmichaelkamal/TrustPilot.CodeChallenge"/>
        /// </summary>
        /// <returns>Maze Id (GUID) as string</returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateMazeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMaze([FromBody] CreateMazeRequest createMazeRequest)
        {
            _logger.LogInformation($"{nameof(CreateMaze)} Calling Create Maze End-Point...");

            var result = await _mazeManager.CreateMaze(createMazeRequest);

            return Created("api/ponymaze", result);
        }

        /// <summary>
        /// Get a maze by <paramref name="mazeId"/>
        /// </summary>
        /// <param name="mazeId"></param>
        /// <returns>Maze Properties like: maze structure, current Pony's location (P)
        /// Domokun's location (D) and the End-Point Location (E).
        /// The location is the number of cells from the beginging till the location itself.
        /// For Example: if the Pony's location is 121 and the Maze Dimention is 15 * 25, then
        /// to get the location, you should divide 121 / 15 (Maze's width) = 8.066666
        /// then you need to subtract the number before the decimal point, so it will be 0.066666
        /// then you need to multiply it with the maze width (15) = 1
        /// finally, the Pony' location is in the 9th row and the 2nd column ((.0666666 * 15) + 1)
        /// </returns>
        [HttpGet("{mazeId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetMazeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMazeById(string mazeId)
        {
            _logger.LogInformation($"{nameof(GetMazeById)} Calling Get Maze End-Point...");

            var response = await _mazeManager.GetMazeById(mazeId);

            return Ok(response);
        }

        /// <summary>
        /// Use this API to move th Pony to any of the four directions, north, east, south or west.
        /// Also, you must provide the <paramref name="mazeId"/>
        /// </summary>
        /// <param name="mazeId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{mazeId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> MovePony(string mazeId, [FromBody] MovePonyRequest request)
        {
            _logger.LogInformation($"{nameof(MovePony)} Calling Move Pony End-Point...");

            if (!Enum.IsDefined(typeof(MoveDirection), request.Direction))
            {
                return BadRequest($"{request} must be {Enum.GetNames(typeof(MoveDirection))}");
            }

            var response = await _mazeManager.MovePony(mazeId, request.Direction);

            return Ok(response);
        }

        /// <summary>
        /// Use this API to print the current state of the maze, with the location of the Pony, 
        /// the Domokun and the End-Point (Target)
        /// </summary>
        /// <param name="mazeId"></param>
        /// <returns></returns>
        [HttpGet("{mazeId}/print")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> PrintMaze(string mazeId)
        {
            _logger.LogInformation($"{nameof(PrintMaze)} Calling Print Maze End-Point...");

            var response = await _mazeManager.PrintMaze(mazeId);

            return Ok(response);
        }

        #endregion
    }
}
