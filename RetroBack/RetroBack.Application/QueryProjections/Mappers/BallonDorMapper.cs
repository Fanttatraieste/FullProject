using RetroBack.Application.Models;
using RetroBack.Domain.Entities;
using RetroBack.Persistence;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static class BallonDorMapper
    {
        public static IQueryable<BallonDorListItemDto> ProjectToDto(this IQueryable<BallonDor> ballonDorQuery, RetroFootballDbContext retroFootballDbContext)
        {
            List<IconPairNameDto> nominations = (from ballon in retroFootballDbContext.BallonDors
                                                 join nom in retroFootballDbContext.BallonDorNominationsStats on ballon.BallonDorId equals nom.BallonId
                                                 join stat in retroFootballDbContext.BallonDorStats on nom.BallonStatId equals stat.StatId
                                                 join icon in retroFootballDbContext.Icons on stat.IconId equals icon.IconId
                                                 select new IconPairNameDto
                                                 {
                                                     IconId = icon.IconId,
                                                     NickName = icon.Nickname,
                                                 }).ToList();

            return ballonDorQuery.Select(x => new BallonDorListItemDto
            {
                BallonDorId = x.BallonDorId,
                Year = x.Year,
                WinnerIconId = x.WinnerIconId,
                RunnerUpIconId = x.RunnerUpIconId,
                ThirdPlaceIconId = x.ThirdPlaceIconId,
                FourthPlaceIconId = x.FourthPlaceIconId,    
                FifthPlaceIconId = x.FifthPlaceIconId,
                SixthPlaceIconId= x.SixthPlaceIconId,
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
            });
        }
    }
}
