using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;
 
namespace RetroBack.Application.Queries.BallonDorQueries
{
    public class BallonDorQueryHandler :
        IRequestHandler<GetBallonDorQuery, CommandResponse<BallonDorDto>>
    {
        private readonly IRepository<BallonDor> _ballonDorRepository;
        private readonly IRepository<BallonDorNominationsStats> _ballonDorNominationsStatsRepository;
        public BallonDorQueryHandler(IRepository<BallonDor> ballonDorRepository, IRepository<BallonDorNominationsStats> ballonDorNominationsStatsRepository)
        {
            _ballonDorRepository = ballonDorRepository;
            _ballonDorNominationsStatsRepository = ballonDorNominationsStatsRepository;
        }

        public async Task<CommandResponse<BallonDorDto>> Handle(GetBallonDorQuery request, CancellationToken cancellationToken)
        {
            var nominations = await _ballonDorNominationsStatsRepository.Query(x => x.BallonDor.BallonDorId == request.BallonDorId).Select(x => new IconPairNameDto
            {
                IconId = x.BallonDorStats.Icon.IconId,
                NickName = x.BallonDorStats.Icon.Nickname
            }).ToListAsync(cancellationToken);

            var existingBallonDor = await _ballonDorRepository.Query(x => x.BallonDorId == request.BallonDorId).Select(x => new BallonDorDto
            {
                BallonDorId = x.BallonDorId,
                WinnerIconId = x.WinnerIconId,
                RunnerUpIconId = x.RunnerUpIconId,
                ThirdPlaceIconId = x.ThirdPlaceIconId,
                FourthPlaceIconId = x.FourthPlaceIconId,
                FifthPlaceIconId = x.FifthPlaceIconId,
                SixthPlaceIconId = x.SixthPlaceIconId,
                SeventhPlaceIconId = x.SeventhPlaceIconId,
                EigthPlaceIconId = x.EigthPlaceIconId,
                NinethPlaceIconId = x.NinethPlaceIconId,
                TenthPlaceIconId = x.TenthPlaceIconId,

                WinnerIconName = x.WinnerIcon.Icon.Nickname,
                RunnerUpIconName = x.RunnerUpIcon.Icon.Nickname,
                ThirdPlaceIconName = x.RunnerUpIcon.Icon.Nickname,
                FourthPlaceIconName = x.FourthPlaceIcon.Icon.Nickname,
                FifthPlaceIconName = x.FifthPlaceIcon.Icon.Nickname,
                SixthPlaceIconName = x.SixthPlaceIcon.Icon.Nickname,
                SeventhPlaceName = x.SeventhPlaceIcon.Icon.Nickname,
                EigthPlaceName = x.EigthPlaceIcon.Icon.Nickname,
                NinethPlaceName = x.NinethPlaceIcon.Icon.Nickname,
                TenthPlaceIconName = x.TenthPlaceIcon.Icon.Nickname,

                Nominations = nominations
            }).FirstOrDefaultAsync(cancellationToken);

            if (existingBallonDor == null)
            {
                return CommandResponse<BallonDorDto>.Failed(ErrorMessages.BallonDor_Does_Not_Exist);
            }

            return CommandResponse<BallonDorDto>.Ok(existingBallonDor);
        }
    }
}
