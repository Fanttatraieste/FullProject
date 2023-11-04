using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections;

namespace RetroBack.Application.Queries.NationQueries
{
    public class GetNationQuery : BaseRequest<CommandResponse<NationDto>>
    {
        public Guid NationId { get; set; }
    }

    public class GetNationsQuery : BaseRequest<CollectionResponse<NationListItemDto>>
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
        public string? NationName { get; set; }
        [FromQuery]
        public string? Confederation { get; set; }
    }
}
