using RetroBack.Application.Common;
using RetroBack.Application.Models;

namespace RetroBack.Application.Queries.BallonDorQueries
{
    public class GetBallonDorQuery : BaseRequest<CommandResponse<BallonDorDto>>
    {
        public Guid BallonDorId { get; set; }
    }
}
