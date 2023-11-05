using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.QueryProjections;
using RetroBack.Application.QueryProjections.Mappers;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;
using RetroBack.Persistence;

namespace RetroBack.Application.Queries.BallonDorStatQueries
{
    public class BallonDorStatQueryHandler :
        IRequestHandler<GetBallonDorStatQuery, CommandResponse<BallonDorStatListItemDto>>,
        IRequestHandler<GetBallonDorStatsQuery, CommandResponse<List<BallonDorStatListItemDto>>>
    {
        private readonly IRepository<BallonDorStats> _ballonDorStatsRepository;
        private readonly RetroFootballDbContext _retroFootballDbContext;

        public BallonDorStatQueryHandler (IRepository<BallonDorStats> ballonDorStatsRepository, RetroFootballDbContext retroFootballDbContext)
        {
            _ballonDorStatsRepository = ballonDorStatsRepository;
            _retroFootballDbContext = retroFootballDbContext;
        }

        public async Task<CommandResponse<BallonDorStatListItemDto>> Handle(GetBallonDorStatQuery request, CancellationToken cancellationToken)
        {
            var existingBallonDorStat = await _ballonDorStatsRepository.Query(b => b.StatId == request.StatId).Select(b => new BallonDorStatListItemDto
            {
                StatId = b.StatId,
                IconID = b.IconId,
                IconName = b.Icon.Nickname,
                BallonDorWins =          (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.WinnerIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorRunnerUps =     (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.RunnerUpIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorThirdPlaces =   (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.ThirdPlaceIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorFourthPlaces =  (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.FourthPlaceIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorFifthPlaces =   (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.FifthPlaceIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorSixthPlaces =   (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.SixthPlaceIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorSeventhPlaces = (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.SeventhPlaceIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorEigthPlaces =   (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.EigthPlaceIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorNinethPlaces =  (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.NinethPlaceIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorTenthPlaces =   (from stat in _retroFootballDbContext.BallonDorStats
                                         join ballon in _retroFootballDbContext.BallonDors on stat.StatId equals ballon.TenthPlaceIconId
                                         select ballon.Year
                                         ).ToList(),
                BallonDorNominations =   (from stat in _retroFootballDbContext.BallonDorStats
                                         join nom in _retroFootballDbContext.BallonDorNominationsStats on stat.StatId equals nom.BallonStatId
                                         join ballon in _retroFootballDbContext.BallonDors on nom.BallonId equals ballon.BallonDorId
                                         select ballon.Year
                                         ).ToList(),
            }).FirstOrDefaultAsync(cancellationToken);

            if (existingBallonDorStat == null)
            {
                return CommandResponse<BallonDorStatListItemDto>.Failed(ErrorMessages.BallonDorStat_Does_Not_Exist);
            }

            return CommandResponse<BallonDorStatListItemDto>.Ok(existingBallonDorStat);
        }

        public async Task<CommandResponse<List<BallonDorStatListItemDto>>> Handle(GetBallonDorStatsQuery request, CancellationToken cancellationToken)
        {
            // filtering
            var ballonDorStatQuery = _ballonDorStatsRepository.Query().ApplyFilter(request);

            // projection
            var ballonDorStatsDtoQuery = ballonDorStatQuery.ProjectToDto(_retroFootballDbContext);

            var existingStatsDtos = await ballonDorStatsDtoQuery.ToListAsync(cancellationToken);

            return new CommandResponse<List<BallonDorStatListItemDto>>(existingStatsDtos);
        }
    }
}
