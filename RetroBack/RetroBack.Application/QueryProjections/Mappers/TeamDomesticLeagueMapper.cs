using RetroBack.Domain.Entities;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static class TeamDomesticLeagueMapper
    {
        public static IQueryable<TeamDomesticLeagueListItemDto> ProjectToDto(this IQueryable<TeamDomesticLeague> leagueQuery)
        {
            return leagueQuery.Select(x => new TeamDomesticLeagueListItemDto
            {
                DomesticLeagueID = x.DomesticLeagueID,
                Country = x.Country,
                Year = x.Year,
                WinnerId = x.WinnerId,
                RunnerUpId = x.RunnerUpId,
                WinnerTeam = x.WinnerTeam.TeamName,
                RunnerUpTeam = x.RunnerUpTeam.TeamName,
            });
        }
    }
}
