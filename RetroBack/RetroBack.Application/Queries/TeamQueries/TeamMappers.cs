using RetroBack.Domain.Entities;

namespace RetroBack.Application.Queries.TeamQueries
{
    public static class TeamFilters
    {
        public static IQueryable<Team> ApplyFilter(this IQueryable<Team> teamsQuery, GetTeamsQuery request)
        {
            if (!string.IsNullOrEmpty(request.TeamName))
                teamsQuery = teamsQuery.Where(e => e.TeamName.Contains(request.TeamName));


            if (!string.IsNullOrEmpty(request.TeamCountry))
                teamsQuery = teamsQuery.Where(e => e.TeamCountry.Contains(request.TeamCountry));


            return teamsQuery;
        }
    }
}
