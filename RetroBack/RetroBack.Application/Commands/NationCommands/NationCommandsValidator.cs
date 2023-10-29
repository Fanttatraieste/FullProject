
using FluentValidation;

namespace RetroBack.Application.Commands.NationCommands
{
    public class NationCreateCommandValidator : AbstractValidator<CreateNationCommand>
    {
        public NationCreateCommandValidator()
        {
            RuleFor(n => n.NationDto).NotNull().NotEmpty();
            RuleFor(n => n.NationDto.NationName).NotNull().NotEmpty();
            RuleFor(n => n.NationDto.Confederation).NotNull().NotEmpty();
        }

    }

    public class NationUpdateCommandValidator : AbstractValidator<UpdateNationCommand>
    {
        public NationUpdateCommandValidator()
        {
            RuleFor(n => n.NationDto).NotNull().NotEmpty();
            RuleFor(n => n.NationDto.NationName).NotNull().NotEmpty();
            RuleFor(n => n.NationDto.Confederation).NotNull().NotEmpty();
        }
    }
}
