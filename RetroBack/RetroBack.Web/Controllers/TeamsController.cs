using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Common;
using RetroBack.Common.Constants;
using RetroBack.Web.Controllers.Base;
using RetroBack.Application.Models;
using RetroBack.Application.Commands.TeamCommands;
using RetroBack.Application.Queries.TeamQueries;
using RetroBack.Application.QueryProjections;

namespace RetroBack.Web.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : BaseController
    {
        public TeamsController()
        {

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse<TeamDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEvent([FromBody] CreateTeamCommand command)
        {
            CommandResponse<TeamDTO> commandResponse = await Mediator.Send(command);
            return commandResponse.IsValid ? Ok(commandResponse) : BadRequest(commandResponse);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateEvent([FromRoute] Guid id, [FromBody] UpdateTeamCommand command)
        {
            if (command.TeamDTO != null)
                command.TeamDTO.TeamID = id;

            CommandResponse commandResponse = await Mediator.Send(command);
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteEvent([FromRoute] Guid id)
        {
            CommandResponse commandResponse = await Mediator.Send(new DeleteTeamCommand { TeamID = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommandResponse<TeamDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEvent([FromRoute] Guid id)
        {
            CommandResponse<TeamDTO> commandResponse = await Mediator.Send(new GetTeamQuery { TeamID = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(CollectionResponse<TeamListItemDTO>), (int)HttpStatusCode.OK)]
        public async Task<CollectionResponse<TeamListItemDTO>> GetEvents([FromQuery] GetTeamsQuery query)
        {
            CollectionResponse<TeamListItemDTO> teamList = await Mediator.Send(query);
            return teamList;
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
