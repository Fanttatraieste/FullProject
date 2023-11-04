using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Commands.BallonDorCommands;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.Queries.BallonDorQueries;
using RetroBack.Common.Constants;
using RetroBack.Web.Controllers.Base;
using System.Net;

namespace RetroBack.Web.Controllers
{
    [ApiController]
    [Route("api/ballondor")]
    public class BallonDorController : BaseController
    {
        public BallonDorController() { }

        [HttpPost("")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse<BallonDorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateBallonDor([FromBody] CreateBallonDorCommand command)
        {
            CommandResponse<BallonDorDto> commandResponse = await Mediator.Send(command);

            return commandResponse.IsValid ? Ok(commandResponse) : BadRequest(commandResponse);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateBallonDor([FromRoute] Guid id, [FromBody] UpdateBallonDorCommand command)
        {
            if (command.BallonDorDto != null)
                command.BallonDorDto.BallonDorId = id;

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
            CommandResponse commandResponse = await Mediator.Send(new DeleteBallonDorCommand { BallonDorId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommandResponse<BallonDorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBallonDor([FromRoute] Guid id)
        {
            CommandResponse<BallonDorDto> commandResponse = await Mediator.Send(new GetBallonDorQuery { BallonDorId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
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
