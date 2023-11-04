using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Commands.IconCommands;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.Queries.IconQueries;
using RetroBack.Application.QueryProjections;
using RetroBack.Common.Constants;
using RetroBack.Web.Controllers.Base;
using System.Net;

namespace RetroBack.Web.Controllers
{
    [ApiController]
    [Route("api/icons")]
    public class IconsController : BaseController
    {
        public IconsController() { }

        [HttpPost("")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse<IconDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateIcon([FromBody] CreateIconCommand command)
        {
            CommandResponse<IconDto> commandResponse = await Mediator.Send(command);

            return commandResponse.IsValid ? Ok(commandResponse) : BadRequest(commandResponse);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateIcon([FromRoute] Guid id, [FromBody] UpdateIconCommand command)
        {
            if (command.IconDto != null)
                command.IconDto.IconId = id;

            CommandResponse commandResponse = await Mediator.Send(command);
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteIcon([FromRoute] Guid id)
        {
            CommandResponse commandResponse = await Mediator.Send(new DeleteIconCommand { IconId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommandResponse<IconDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetIcon([FromRoute] Guid id)
        {
            CommandResponse<IconDto> commandResponse = await Mediator.Send(new GetIconQuery { IconId = id });
            return commandResponse.IsValid ? Ok(commandResponse) : FormatError(commandResponse);
        }

        [HttpGet("/GetAllIcons")]
        [ProducesResponseType(typeof(CollectionResponse<IconListItemDto>), (int)HttpStatusCode.OK)]
        public async Task<CollectionResponse<IconListItemDto>> GetAllIcons([FromQuery] GetIconsQuery query)
        {
            CollectionResponse<IconListItemDto> teamList = await Mediator.Send(query);
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
