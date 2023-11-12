using RetroBack.Domain.Entities;

namespace RetroBack.Application.Queries.TeamDomesticLeagueQueries
{
    public static class TeamDomesticLeagueFilter
    {
        public static IQueryable<TeamDomesticLeague> ApplyFilter(this IQueryable<TeamDomesticLeague> leagueQuery, GetDomesticLeaguesQuery request)
        {
            if (!string.IsNullOrEmpty(request.Country))
                leagueQuery = leagueQuery.Where(l => l.Country == request.Country);
            if (request.Year > 0)
                leagueQuery = leagueQuery.Where(l => l.Year == request.Year);

            return leagueQuery;
        }
    }
}
