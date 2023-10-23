using FluentValidation;

namespace RetroBack.Application.Commands.TeamCommands
{
    public class TeamCreationCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public TeamCreationCommandValidator() 
        {
            RuleFor(t => t.TeamDTO).NotNull();
            RuleFor(e => e.TeamDTO.TeamName).NotNull().NotEmpty().MaximumLength(256);
            RuleFor(e => e.TeamDTO.TeamCountry).NotNull().NotEmpty().MaximumLength(256);
        }
    }

    public class TeamUpdateCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public TeamUpdateCommandValidator()
        {
            RuleFor(t => t.TeamDTO).NotNull();
            RuleFor(e => e.TeamDTO.TeamName).NotNull().NotEmpty().MaximumLength(256);
            RuleFor(e => e.TeamDTO.TeamCountry).NotNull().NotEmpty().MaximumLength(256);
        }
    }

}
