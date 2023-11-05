using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Commands.BallonDorStatCommands;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.Queries.BallonDorStatQueries;
using RetroBack.Application.QueryProjections;
using RetroBack.Common.Constants;
using RetroBack.Web.Controllers.Base;
using System.Net;

namespace RetroBack.Web.Controllers
{
    [ApiController]
    [Route("api/ballondor/stats")]
    public class BallonDorStatController : BaseController
    {
        public BallonDorStatController() { }

        [HttpPost("")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse<BallonDorStatDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateBallonDorStat([FromBody] CreateBallonDorStatCommand command)
        {
            CommandResponse<BallonDorStatDto> commandResponse = await Mediator.Send(command);

            return commandResponse.IsValid ? Ok(commandResponse) : BadRequest(commandResponse);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateBallonDorStat([FromRoute] Guid id, [FromBody] UpdateBallonDorStatCommand command)
        {
            if (command.BallonDorStatDto != null)
                command.BallonDorStatDto.StatId = id;

            CommandResponse commandResponse = await Mediator.Send(command);
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteBallonDor([FromRoute] Guid id)
        {
            CommandResponse commandResponse = await Mediator.Send(new DeleteBallonDorStatCommand { BallonDorStatId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommandResponse<BallonDorStatListItemDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBallonDor([FromRoute] Guid id)
        {
            CommandResponse<BallonDorStatListItemDto> commandResponse = await Mediator.Send(new GetBallonDorStatQuery { StatId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("/getAllStats")]
        [ProducesResponseType(typeof(CommandResponse<List<BallonDorStatListItemDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<CommandResponse<List<BallonDorStatListItemDto>>> GetAllBallonDors([FromQuery] GetBallonDorStatsQuery query)
        {
            CommandResponse<List<BallonDorStatListItemDto>> ballonDorList = await Mediator.Send(query);
            return ballonDorList;
        }

        private IActionResult FormatError(CommandResponse commandResponse)
        {
            if (commandResponse.Errors.ContainsKey(""))
            {
                if (commandResponse.Errors[""].Contains(ErrorMessages.Team_Does_Not_Exist))
                {
                    return NotFound();
                }
            }

            return BadRequest(commandResponse);
        }
    }
}
