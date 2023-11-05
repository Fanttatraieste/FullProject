using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections;
using RetroBack.Application.QueryProjections.Mappers;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;
using RetroBack.Persistence;

namespace RetroBack.Application.Queries.BallonDorQueries
{
    public class BallonDorQueryHandler :
        IRequestHandler<GetBallonDorQuery, CommandResponse<BallonDorDto>>,
        IRequestHandler<GetBallonDorsQuery, CommandResponse<List<BallonDorListItemDto>>>
    {
        private readonly IRepository<BallonDor> _ballonDorRepository;
        private readonly RetroFootballDbContext _retroFootballDbContext;
        public BallonDorQueryHandler(IRepository<BallonDor> ballonDorRepository, RetroFootballDbContext retroFootballDbContext)
        {
            _ballonDorRepository = ballonDorRepository;
            _retroFootballDbContext = retroFootballDbContext;
        }

        public async Task<CommandResponse<BallonDorDto>> Handle(GetBallonDorQuery request, CancellationToken cancellationToken)
        {
            var nominations = (from stat in _retroFootballDbContext.BallonDorStats
                               join nom in _retroFootballDbContext.BallonDorNominationsStats on stat.StatId equals nom.BallonStatId
                               join ballon in _retroFootballDbContext.BallonDors on nom.BallonId equals ballon.BallonDorId
                               select new IconPairNameDto
                               {
                                   IconId = stat.IconId,
                                   NickName = stat.Icon.Nickname
                               }
                              ).ToList();

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
                ThirdPlaceIconName = x.ThirdPlaceIcon.Icon.Nickname,
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

        public async Task<CommandResponse<List<BallonDorListItemDto>>> Handle(GetBallonDorsQuery request, CancellationToken cancellationToken)
        {
            // filtering
            var ballonDorQuery = _ballonDorRepository.Query().ApplyFilter(request);

            // projection 
            var ballonDorDtoQuery = ballonDorQuery.ProjectToDto(_retroFootballDbContext);

            var existingBallonDorsDtos = await ballonDorDtoQuery.ToListAsync(cancellationToken);

            return new CommandResponse<List<BallonDorListItemDto>>(existingBallonDorsDtos);
        }
    }
}
