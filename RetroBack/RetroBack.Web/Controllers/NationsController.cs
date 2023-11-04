using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Commands.NationCommands;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.Queries.NationQueries;
using RetroBack.Application.Queries.TeamQueries;
using RetroBack.Application.QueryProjections;
using RetroBack.Common.Constants;
using RetroBack.Web.Controllers.Base;
using System.Net;

namespace RetroBack.Web.Controllers
{
    [ApiController]
    [Route("api/nations")]
    public class NationsController : BaseController
    {
        public NationsController() { }

        [HttpPost("")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse<NationDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateNation([FromBody] CreateNationCommand command)
        {
            CommandResponse<NationDto> commandResponse = await Mediator.Send(command);

            return commandResponse.IsValid ? Ok(commandResponse) : BadRequest(commandResponse);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateNation([FromRoute] Guid id, [FromBody] UpdateNationCommand command)
        {
            if (command.NationDto != null)
                command.NationDto.NationId = id;

            CommandResponse commandResponse = await Mediator.Send(command);
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteNation([FromRoute] Guid id)
        {
            CommandResponse commandResponse = await Mediator.Send(new DeleteNationCommand { NationId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommandResponse<NationDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetNation([FromRoute] Guid id)
        {
            CommandResponse<NationDto> commandResponse = await Mediator.Send(new GetNationQuery { NationId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("/GetAllNations")]
        [ProducesResponseType(typeof(CollectionResponse<NationListItemDto>), (int)HttpStatusCode.OK)]
        public async Task<CollectionResponse<NationListItemDto>> GetNations([FromQuery] GetNationsQuery query)
        {
            CollectionResponse<NationListItemDto> teamList = await Mediator.Send(query);
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
