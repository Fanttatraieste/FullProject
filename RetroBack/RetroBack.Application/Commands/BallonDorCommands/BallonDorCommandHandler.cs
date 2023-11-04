using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Commands.BallonDorCommands
{
    public class BallonDorCommandHandler :
        IRequestHandler<CreateBallonDorCommand, CommandResponse<BallonDorDto>>,
        IRequestHandler<UpdateBallonDorCommand, CommandResponse>,
        IRequestHandler<DeleteBallonDorCommand, CommandResponse>
    {
        private readonly IRepository<BallonDor> _ballonDorRepository;
        public BallonDorCommandHandler(IRepository<BallonDor> ballonDorRepository)
        {
            _ballonDorRepository = ballonDorRepository;
        }
    
        public async Task<CommandResponse<BallonDorDto>> Handle(CreateBallonDorCommand request, CancellationToken cancellationToken)
        {
            request.BallonDorDto.BallonDorId = Guid.NewGuid();

            var newBallonDor = new BallonDor()
            {
                BallonDorId = request.BallonDorDto.BallonDorId,
                WinnerIconId = request.BallonDorDto.WinnerIconId,
                RunnerUpIconId = request.BallonDorDto.RunnerUpIconId,
                ThirdPlaceIconId = request.BallonDorDto.ThirdPlaceIconId,
                FourthPlaceIconId = request.BallonDorDto.FourthPlaceIconId,
                FifthPlaceIconId = request.BallonDorDto.FifthPlaceIconId,
                SixthPlaceIconId = request.BallonDorDto.SixthPlaceIconId,
                SeventhPlaceIconId = request.BallonDorDto.SeventhPlaceIconId,
                EigthPlaceIconId = request.BallonDorDto.EigthPlaceIconId,
                NinethPlaceIconId = request.BallonDorDto.NinethPlaceIconId,
                TenthPlaceIconId = request.BallonDorDto.TenthPlaceIconId,
            };

            _ballonDorRepository.Add(newBallonDor);

            await _ballonDorRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(CommandResponse<BallonDorDto>.Ok(request.BallonDorDto));
        }

        public async Task<CommandResponse> Handle(UpdateBallonDorCommand request, CancellationToken cancellationToken)
        {
            var existingBallonDor = await _ballonDorRepository.Query(b => b.BallonDorId == request.BallonDorDto.BallonDorId).FirstOrDefaultAsync(cancellationToken);

            if (existingBallonDor == null)
            {
                return CommandResponse.Failed(ErrorMessages.BallonDor_Does_Not_Exist);
            }

            existingBallonDor.WinnerIconId = request.BallonDorDto.BallonDorId;
            existingBallonDor.RunnerUpIconId = request.BallonDorDto.RunnerUpIconId;
            existingBallonDor.ThirdPlaceIconId = request.BallonDorDto.ThirdPlaceIconId;
            existingBallonDor.FourthPlaceIconId = request.BallonDorDto.FourthPlaceIconId;
            existingBallonDor.FifthPlaceIconId = request.BallonDorDto.FifthPlaceIconId;
            existingBallonDor.SixthPlaceIconId = request.BallonDorDto.SixthPlaceIconId;
            existingBallonDor.SeventhPlaceIconId = request.BallonDorDto.SeventhPlaceIconId;
            existingBallonDor.EigthPlaceIconId = request.BallonDorDto.EigthPlaceIconId;
            existingBallonDor.NinethPlaceIconId = request.BallonDorDto.NinethPlaceIconId;
            existingBallonDor.TenthPlaceIconId = request.BallonDorDto.TenthPlaceIconId;

            await _ballonDorRepository.SaveChangesAsync(cancellationToken);
            return CommandResponse.Ok();
        }

        public async Task<CommandResponse> Handle(DeleteBallonDorCommand request, CancellationToken cancellationToken)
        {
            var existingBallonDor = await _ballonDorRepository.Query(b => b.BallonDorId == request.BallonDorId).FirstOrDefaultAsync(cancellationToken);

            if (existingBallonDor == null)
            {
                return CommandResponse.Failed(ErrorMessages.BallonDor_Does_Not_Exist);
            }

            _ballonDorRepository.Remove(existingBallonDor);

            await _ballonDorRepository.SaveChangesAsync(cancellationToken);

            return CommandResponse.Ok();
        }
    }
}
