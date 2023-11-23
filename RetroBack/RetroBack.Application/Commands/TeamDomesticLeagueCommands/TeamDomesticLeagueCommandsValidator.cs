using FluentValidation;

namespace RetroBack.Application.Commands.TeamDomesticLeagueCommands
{
    public  class TeamDomesticLeagueCreateCommandValidator : AbstractValidator<CreateTeamDomesticLeagueCommand>
    {
        public TeamDomesticLeagueCreateCommandValidator()
        {
            RuleFor(l => l.TeamDomesticLeagueDto).NotNull().NotEmpty();
            RuleFor(l => l.TeamDomesticLeagueDto.Year).NotNull();  
        }
    }

    public class TeamDomesticLeagueUpdateCommandValidator : AbstractValidator<UpdateTeamDomesticLeagueCommand>
    {
        public TeamDomesticLeagueUpdateCommandValidator()
        {
            RuleFor(l => l.TeamDomesticLeagueDto).NotNull().NotEmpty();
            RuleFor(l => l.TeamDomesticLeagueDto.Year).NotNull();
        }
    }
}
