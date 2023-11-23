using FluentValidation;

namespace RetroBack.Application.Commands.TeamDomesticSuperCupCommands
{
    public class TeamDomesticSuperCupCreateCommandValidator: AbstractValidator<CreateTeamDomesticSuperCupCommand>
    {
        public TeamDomesticSuperCupCreateCommandValidator()
        {
            RuleFor(s => s.TeamDomesticSuperCupDto).NotNull().NotEmpty();
            RuleFor(s => s.TeamDomesticSuperCupDto.Year).NotNull();
            RuleFor(s => s.TeamDomesticSuperCupDto.WinnerId).NotNull().NotEmpty();
        }
    }

    public class TeamDomesticSuperCupUpdateCommandValidator: AbstractValidator<UpdateTeamDomesticSuperCupCommand>
    {
        public TeamDomesticSuperCupUpdateCommandValidator()
        {
            RuleFor(s => s.TeamDomesticSuperCupDto).NotNull().NotEmpty();
            RuleFor(s => s.TeamDomesticSuperCupDto.Year).NotNull();
            RuleFor(s => s.TeamDomesticSuperCupDto.WinnerId).NotNull().NotEmpty();
        }
    }
}
