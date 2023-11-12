using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Common;
using RetroBack.Application.QueryProjections;

namespace RetroBack.Application.Queries.TeamDomesticLeagueQueries
{
    public class GetDomesticLeagueQuery : BaseRequest<CommandResponse<TeamDomesticLeagueListItemDto>>
    {
        public Guid LeagueId { get; set; }
    }

    public class GetDomesticLeaguesQuery : BaseRequest<CollectionResponse<TeamDomesticLeagueListItemDto>>
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
        public string? Country { get; set; }
        [FromQuery]
        public int? Year { get; set; }
    }
}
