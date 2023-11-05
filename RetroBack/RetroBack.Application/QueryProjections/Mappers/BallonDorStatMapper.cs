using RetroBack.Domain.Entities;
using RetroBack.Persistence;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static class BallonDorStatMapper
    {
        public static IQueryable<BallonDorStatListItemDto> ProjectToDto(this IQueryable<BallonDorStats> ballonDorStatQuery, RetroFootballDbContext retroFootballDbContext)
        {
            //List<int> wins = (from stat in retroFootballDbContext.BallonDorStats
            //                 join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.WinnerIconId
            //                  select ballon.Year
            //                 ).ToList();

            //List<int> runnerups = (from stat in retroFootballDbContext.BallonDorStats
            //                      join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.RunnerUpIconId
            //                      select ballon.Year
            //                      ).ToList();

            //List<int> thirdPlaces = (from stat in retroFootballDbContext.BallonDorStats
            //                        join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.ThirdPlaceIconId
            //                        select ballon.Year
            //                        ).ToList();

            //List<int> fourthPlaces = (from stat in retroFootballDbContext.BallonDorStats
            //                         join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.FourthPlaceIconId
            //                         select ballon.Year
            //                         ).ToList();

            //List<int> fifthPlaces = (from stat in retroFootballDbContext.BallonDorStats
            //                        join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.FifthPlaceIconId
            //                        select ballon.Year
            //                        ).ToList();

            //List<int> sixthPlaces = (from stat in retroFootballDbContext.BallonDorStats
            //                        join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.SixthPlaceIconId
            //                        select ballon.Year
            //                        ).ToList();

            //List<int> seventhPlaces = (from stat in retroFootballDbContext.BallonDorStats
            //                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.SeventhPlaceIconId
            //                          select ballon.Year
            //                          ).ToList();

            //List<int> eigthPlaces = (from stat in retroFootballDbContext.BallonDorStats
            //                        join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.EigthPlaceIconId
            //                        select ballon.Year
            //                        ).ToList();

            //List<int> ninethPlaces = (from stat in retroFootballDbContext.BallonDorStats
            //                         join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.NinethPlaceIconId
            //                         select ballon.Year
            //                         ).ToList();

            //List<int> tenthPlaces = (from stat in retroFootballDbContext.BallonDorStats
            //                        join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.TenthPlaceIconId
            //                        select ballon.Year
            //                        ).ToList();

            List<int> nominations = (from stat in retroFootballDbContext.BallonDorStats
                                     join nom in retroFootballDbContext.BallonDorNominationsStats on stat.StatId equals nom.BallonStatId
                                     join ballon in retroFootballDbContext.BallonDors on nom.BallonId equals ballon.BallonDorId
                                     select ballon.Year
                                    ).ToList();

            return ballonDorStatQuery.Select(x => new BallonDorStatListItemDto
            {
                StatId = x.StatId,
                IconID = x.IconId,
                IconName = x.Icon.Nickname,
                BallonDorWins =           (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.WinnerIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorRunnerUps =      (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.RunnerUpIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorThirdPlaces =    (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.ThirdPlaceIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorFourthPlaces =   (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.FourthPlaceIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorFifthPlaces =    (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.FifthPlaceIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorSixthPlaces =    (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.SixthPlaceIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorSeventhPlaces =  (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.SeventhPlaceIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorEigthPlaces =    (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.EigthPlaceIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorNinethPlaces =   (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.NinethPlaceIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorTenthPlaces =    (from stat in retroFootballDbContext.BallonDorStats
                                          join ballon in retroFootballDbContext.BallonDors on stat.StatId equals ballon.TenthPlaceIconId
                                          where stat.StatId == x.StatId
                                          select ballon.Year
                                          ).ToList(),
                BallonDorNominations = nominations,
        });
        }
    }
}
