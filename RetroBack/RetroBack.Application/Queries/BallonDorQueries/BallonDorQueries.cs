using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections;

namespace RetroBack.Application.Queries.BallonDorQueries
{
    public class GetBallonDorQuery : BaseRequest<CommandResponse<BallonDorDto>>
    {
        public Guid BallonDorId { get; set; }
    }

    public class GetBallonDorsQuery : BaseRequest<CommandResponse<List<BallonDorListItemDto>>> 
    {
        [FromQuery]
        public int? Year { get; set; }
    }
}
