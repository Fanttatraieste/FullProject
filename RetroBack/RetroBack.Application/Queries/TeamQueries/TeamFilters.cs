using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroBack.Application.QueryProjections;
using RetroBack.Domain.Entities;

namespace RetroBack.Application.Queries.TeamQueries
{
    public static class TeamFilters
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
