using RetroBack.Application.Queries.TeamQueries;
using RetroBack.Domain.Entities;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static  class TeamMappers
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
