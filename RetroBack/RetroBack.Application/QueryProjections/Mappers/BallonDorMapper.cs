using RetroBack.Domain.Entities;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static class BallonDorMapper
    {
        public static IQueryable<BallonDorListItemDto> ProjectToDto(this IQueryable<BallonDor> ballonDorQuery)
        {
            return ballonDorQuery.Select(x => new BallonDorListItemDto
            {
                BallonDorId = x.BallonDorId,
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
                ThirdPlaceIconName = x.RunnerUpIcon.Icon.Nickname,
                FourthPlaceIconName = x.FourthPlaceIcon.Icon.Nickname,
                FifthPlaceIconName = x.FifthPlaceIcon.Icon.Nickname,
                SixthPlaceIconName = x.SixthPlaceIcon.Icon.Nickname,
                SeventhPlaceName = x.SeventhPlaceIcon.Icon.Nickname,
                EigthPlaceName = x.EigthPlaceIcon.Icon.Nickname,
                NinethPlaceName = x.NinethPlaceIcon.Icon.Nickname,
                TenthPlaceIconName = x.TenthPlaceIcon.Icon.Nickname,
            });
        }
    }
}
