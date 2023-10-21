using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.Queries.AccountQueries;
using RetroBack.Web.Controllers.Base;
using System.Net;

namespace RetroBack.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        public AccountController()
        {

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApplicationUserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ApplicationUserDto> GetLoggedInUser()
        {
            ApplicationUserDto commandResponse =
                await Mediator.Send(new GetLoggedInUserQuery());

            return commandResponse;
        }
    }
}
