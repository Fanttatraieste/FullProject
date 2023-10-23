using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections;

namespace RetroBack.Application.Queries.TeamQueries
{
    public class GetTeamQuery : BaseRequest<CommandResponse<TeamDTO>>
    {
        public Guid TeamID { get; set; }
    }

    public class GetTeamsQuery : BaseRequest<CollectionResponse<TeamListItemDTO>>
    {
        // pagination

        [FromQuery]
        public int Skip { get; set; }

        [FromQuery]
        public int Take { get; set; }

        // sorting
        [FromQuery]
        public string? SortBy { get; set; }

        [FromQuery]
        public string? SortDir { get; set; }


        // filtering
        [FromQuery]
        public string? TeamName { get; set; }
        [FromQuery]
        public string? TeamCountry { get; set; }
    }
}
