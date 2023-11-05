using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Commands.BallonDorStatCommands
{
    public class BallonDorStatCommandHandler :
        IRequestHandler<CreateBallonDorStatCommand, CommandResponse<BallonDorStatDto>>,
        //IRequestHandler<UpdateBallonDorStatCommand, CommandResponse>,
        IRequestHandler<DeleteBallonDorStatCommand, CommandResponse>
    {
        private readonly IRepository<BallonDorStats> _ballonDorStatsRepository;
        public BallonDorStatCommandHandler(IRepository<BallonDorStats> ballonDorStatsRepository)
        {
            _ballonDorStatsRepository = ballonDorStatsRepository;
        }

        public async Task<CommandResponse<BallonDorStatDto>> Handle(CreateBallonDorStatCommand request, CancellationToken cancellationToken)
        {
            request.BallonDorStatDto.StatId = Guid.NewGuid();

            var newBallonDorStat = new BallonDorStats()
            {
                StatId = request.BallonDorStatDto.StatId,
                IconId = request.BallonDorStatDto.IconId,
            };

            _ballonDorStatsRepository.Add(newBallonDorStat);

            await _ballonDorStatsRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(CommandResponse<BallonDorStatDto>.Ok(request.BallonDorStatDto));
        }

        //public async Task<CommandResponse> Handle(UpdateBallonDorStatCommand request, CancellationToken cancellationToken)
        //{
        //    var existingBallonDorStat = await _ballonDorStatsRepository.Query(b => b.StatId == request.BallonDorStatDto.StatId).FirstOrDefaultAsync(cancellationToken);

        //    if (existingBallonDorStat == null)
        //    {
        //        return CommandResponse.Failed(ErrorMessages.BallonDorStat_Does_Not_Exist);
        //    }

        //    existingBallonDorStat.Ic
        //}

        public async Task<CommandResponse> Handle(DeleteBallonDorStatCommand request, CancellationToken cancellationToken)
        {
            var existingBallonDorStat = await _ballonDorStatsRepository.Query(b => b.StatId == request.BallonDorStatId).FirstOrDefaultAsync(cancellationToken);

            if (existingBallonDorStat == null)
            {
                return CommandResponse.Failed(ErrorMessages.BallonDorStat_Does_Not_Exist);
            }

            _ballonDorStatsRepository.Remove(existingBallonDorStat);

            await _ballonDorStatsRepository.SaveChangesAsync(cancellationToken);

            return CommandResponse.Ok();
        }
    }
}
