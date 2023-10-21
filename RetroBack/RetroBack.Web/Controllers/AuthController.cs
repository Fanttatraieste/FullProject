using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Commands.AuthCommands;
using RetroBack.Application.Common;
using RetroBack.Web.Controllers.Base;
using System.Net;

namespace RetroBack.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        public AuthController()
        {
        }

        [HttpPost("Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(UserRegistrationCommand userRegistrationCommand)
        {
            CommandResponse commandResponse = await Mediator.Send(userRegistrationCommand);

            return commandResponse.IsValid ? Ok(commandResponse) : BadRequest(commandResponse);
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(CommandResponse<UserLoginCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login(UserLoginCommand userLoginCommand)
        {
            CommandResponse<UserLoginCommandResponse> commandResponse = await Mediator.Send(userLoginCommand);

            return commandResponse.IsValid ? Ok(commandResponse) : BadRequest(commandResponse);
        }
    }
}
