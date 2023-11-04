using RetroBack.Domain.Entities;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static class IconMapper
    {
        public static IQueryable<IconListItemDto> ProjectToDto(this IQueryable<Icon> iconQuery)
        {
            return iconQuery.Select(x => new IconListItemDto
            {
                IconId = x.IconId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Nickname = x.Nickname,
                YearOfBirth = x.YearOfBirth,
                Description = x.Description,
                CareerLengthInYears = x.CareerLengthInYears,
                RetiredInYear = x.RetiredInYear,
                CareerGames = x.CareerGames,
                CareerGoals = x.CareerGoals,
                IconCountry = x.NationIconStats.Nation.NationName,
                Position = x.Position,  
            });
        }
    }
}
