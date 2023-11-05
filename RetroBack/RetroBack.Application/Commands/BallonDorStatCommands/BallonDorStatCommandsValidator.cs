
using FluentValidation;
using RetroBack.Application.Commands.BallonDorCommands;

namespace RetroBack.Application.Commands.BallonDorStatCommands
{
    public class BallonDorStatCreateCommandValidator : AbstractValidator<CreateBallonDorStatCommand>
    {
        public BallonDorStatCreateCommandValidator()
        {
            RuleFor(b => b.BallonDorStatDto).NotNull().NotEmpty();
        }
    }

    public class BallonDorStatUpdateCommandValidator : AbstractValidator<UpdateBallonDorStatCommand>
    {
        public BallonDorStatUpdateCommandValidator()
        {
            RuleFor(b => b.BallonDorStatDto).NotNull().NotEmpty();
        }
    }
}
