using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Interfaces;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections.Mappers;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;


namespace RetroBack.Application.Commands.AuthCommands
{
    public class AuthCommandHandler : IRequestHandler<UserRegistrationCommand, CommandResponse>,
        IRequestHandler<UserLoginCommand, CommandResponse<UserLoginCommandResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRepository<ApplicationUser> _userRepository;

        public AuthCommandHandler(UserManager<ApplicationUser> userManager,
            IJwtTokenService jwtTokenService,
            IRepository<ApplicationUser> userRepository)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        public async Task<CommandResponse> Handle(UserRegistrationCommand command, CancellationToken cancellationToken)
        {
            var applicationUser = new ApplicationUser
            {
                Email = command.Email,
                UserName = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DisplayName = command.DisplayName,
                EmailConfirmed = false
            };

            IdentityResult result = await _userManager.CreateAsync(applicationUser, command.Password);
            if (result.Succeeded)
                result = await _userManager.AddToRoleAsync(applicationUser, Roles.User);

            return result.Succeeded
                ? CommandResponse.Ok()
                : CommandResponse.Failed(result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task<CommandResponse<UserLoginCommandResponse>> Handle(UserLoginCommand command, CancellationToken cancellationToken)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(command.Email);

            if (applicationUser.IsDisabledByAdmin)
            {
                return CommandResponse<UserLoginCommandResponse>.Failed(ErrorMessages.API_UserLoginCommand_DisabledUser);
            }

            if (applicationUser is null)
            {
                return CommandResponse<UserLoginCommandResponse>.Failed(ErrorMessages.API_UserLoginCommand_InvalidUserInformation);
            }

            bool passwordValid = await _userManager.CheckPasswordAsync(applicationUser, command.Password);

            if (!passwordValid)
            {
                return CommandResponse<UserLoginCommandResponse>.Failed(ErrorMessages.API_UserLoginCommand_InvalidUserInformation);
            }

            ApplicationUserDto applicationUserDto = await _userRepository.Query(u => u.Id == applicationUser.Id).ProjectToDto().FirstOrDefaultAsync(cancellationToken);

            var response = new UserLoginCommandResponse
            {
                Token = _jwtTokenService.CreateToken(applicationUser, applicationUserDto.Roles),
                User = applicationUserDto
            };

            return CommandResponse<UserLoginCommandResponse>.Ok(response);
        }
    }
}
