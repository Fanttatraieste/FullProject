using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Commands.TeamDomesticLeagueCommands;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.Queries.IconQueries;
using RetroBack.Application.Queries.TeamDomesticLeagueQueries;
using RetroBack.Application.QueryProjections;
using RetroBack.Common.Constants;
using RetroBack.Web.Controllers.Base;
using System.Net;

namespace RetroBack.Web.Controllers
{
    [ApiController]
    [Route("api/leagues")]
    public class DomesticLeagueController : BaseController
    {
        public DomesticLeagueController() { }

        [HttpPost("")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse<TeamDomesticLeagueDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLeague([FromBody] CreateTeamDomesticLeagueCommand command)
        {
            CommandResponse<TeamDomesticLeagueDto> commandResponse = await Mediator.Send(command);

            return commandResponse.IsValid ? Ok(commandResponse) : BadRequest(commandResponse);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateLeague([FromRoute] Guid id, [FromBody] UpdateTeamDomesticLeagueCommand command)
        {
            if (command.TeamDomesticLeagueDto != null)
                command.TeamDomesticLeagueDto.DomesticLeagueID = id;

            CommandResponse commandResponse = await Mediator.Send(command);
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteLeague([FromRoute] Guid id)
        {
            CommandResponse commandResponse = await Mediator.Send(new DeleteTeamDomesticLeagueCommand { LeagueId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommandResponse<TeamDomesticLeagueListItemDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetLeague([FromRoute] Guid id)
        {
            CommandResponse<TeamDomesticLeagueListItemDto> commandResponse = await Mediator.Send(new GetDomesticLeagueQuery { LeagueId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("/GetAllLeagues")]
        [ProducesResponseType(typeof(CollectionResponse<TeamDomesticLeagueListItemDto>), (int)HttpStatusCode.OK)]
        public async Task<CollectionResponse<TeamDomesticLeagueListItemDto>> GetAllLeagues([FromQuery] GetDomesticLeaguesQuery query)
        {
            CollectionResponse<TeamDomesticLeagueListItemDto> iconList = await Mediator.Send(query);
            return iconList;
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
