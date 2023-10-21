using RetroBack.Application.Common;
using RetroBack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Application.Commands.AuthCommands
{
    public class UserRegistrationCommand : BaseRequest<CommandResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }
    }

    public class UserLoginCommand : BaseRequest<CommandResponse<UserLoginCommandResponse>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class UserLoginCommandResponse
    {
        public string Token { get; set; }

        public bool IsNewUser { get; set; }

        public ApplicationUserDto User { get; set; }
    }
}
