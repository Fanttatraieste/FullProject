using RetroBack.Application.QueryProjections;
using RetroBack.Domain.Entities;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static class TeamMapper
    {
        public static IQueryable<TeamListItemDTO> ProjectToDTO(this IQueryable<Team> teamQuery)
        {
            return teamQuery.Select(t => new TeamListItemDTO
            {
                TeamID = t.TeamID,
                TeamCountry = t.TeamCountry,
                TeamName = t.TeamName
            });
        }
    }
}
