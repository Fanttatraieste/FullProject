using FluentValidation;

namespace RetroBack.Application.Commands.BallonDorCommands
{
    public class BallonDorCreateCommandValidator : AbstractValidator<CreateBallonDorCommand>
    {
        public BallonDorCreateCommandValidator()
        {
            RuleFor(b => b.BallonDorDto).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.WinnerIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.RunnerUpIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.ThirdPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.FourthPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.FifthPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.SixthPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.SeventhPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.EigthPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.NinethPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.TenthPlaceIconId).NotNull().NotEmpty();
        }
    }

    public class BallonDorUpdateCommandValidator : AbstractValidator<UpdateBallonDorCommand>
    {
        public BallonDorUpdateCommandValidator()
        {
            RuleFor(b => b.BallonDorDto).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.WinnerIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.RunnerUpIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.ThirdPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.FourthPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.FifthPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.SixthPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.SeventhPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.EigthPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.NinethPlaceIconId).NotNull().NotEmpty();
            RuleFor(b => b.BallonDorDto.TenthPlaceIconId).NotNull().NotEmpty();
        }
    }
}
