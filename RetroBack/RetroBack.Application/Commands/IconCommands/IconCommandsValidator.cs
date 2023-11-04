
using FluentValidation;

namespace RetroBack.Application.Commands.IconCommands
{
    public class IconCreateCommandValidator : AbstractValidator<CreateIconCommand>
    {
        public IconCreateCommandValidator()
        {
            RuleFor(i => i.IconDto).NotNull().NotEmpty();
            RuleFor(i => i.IconDto.FirstName).NotNull().NotEmpty().MaximumLength(450);
            RuleFor(i => i.IconDto.LastName).NotNull().NotEmpty().MaximumLength(450);
            RuleFor(i => i.IconDto.Nickname).NotNull().NotEmpty().MaximumLength(256);
            RuleFor(i => i.IconDto.CareerGames).NotNull().NotEmpty().GreaterThanOrEqualTo(200);
            RuleFor(i => i.IconDto.CareerGoals).NotNull().NotEmpty().LessThanOrEqualTo(2000);
            RuleFor(i => i.IconDto.CareerLengthInYears).NotNull().NotEmpty().GreaterThanOrEqualTo(10);
            RuleFor(i => i.IconDto.RetiredInYear).NotNull().NotEmpty().GreaterThanOrEqualTo(1930);
            RuleFor(i => i.IconDto.YearOfBirth).NotNull().NotEmpty().GreaterThanOrEqualTo(1900);
        }
    }

    public class IconUpdateCommandValidator : AbstractValidator<UpdateIconCommand>
    {
        public IconUpdateCommandValidator()
        {
            RuleFor(i => i.IconDto).NotNull().NotEmpty();
            RuleFor(i => i.IconDto.FirstName).NotNull().NotEmpty().MaximumLength(450);
            RuleFor(i => i.IconDto.LastName).NotNull().NotEmpty().MaximumLength(450);
            RuleFor(i => i.IconDto.Nickname).NotNull().NotEmpty().MaximumLength(256);
            RuleFor(i => i.IconDto.CareerGames).NotNull().NotEmpty().GreaterThanOrEqualTo(200);
            RuleFor(i => i.IconDto.CareerGoals).NotNull().NotEmpty().LessThanOrEqualTo(2000);
            RuleFor(i => i.IconDto.CareerLengthInYears).NotNull().NotEmpty().GreaterThanOrEqualTo(10);
            RuleFor(i => i.IconDto.RetiredInYear).NotNull().NotEmpty().GreaterThanOrEqualTo(1930);
            RuleFor(i => i.IconDto.YearOfBirth).NotNull().NotEmpty().GreaterThanOrEqualTo(1900);
        }
    }

}
