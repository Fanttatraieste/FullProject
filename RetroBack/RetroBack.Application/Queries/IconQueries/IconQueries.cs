using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections;

namespace RetroBack.Application.Queries.IconQueries
{
    public class GetIconQuery : BaseRequest<CommandResponse<IconDto>>
    {
        public Guid IconId { get; set; }
    }

    public class GetIconsQuery : BaseRequest<CollectionResponse<IconListItemDto>>
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
        public string? FirstName { get; set; }
        [FromQuery]
        public string? LastName { get; set; }
        [FromQuery]
        public string? Nickname { get; set; }
        [FromQuery]
        public string? Country { get; set; }
        [FromQuery]
        public int? RetiredInYear { get; set; }
        [FromQuery]
        public string? Position { get; set; }
    }
}