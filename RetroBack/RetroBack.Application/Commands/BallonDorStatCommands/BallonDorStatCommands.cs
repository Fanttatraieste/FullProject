
using RetroBack.Application.Common;
using RetroBack.Application.Models;

namespace RetroBack.Application.Commands.BallonDorStatCommands
{
    public class CreateBallonDorStatCommand : BaseRequest<CommandResponse<BallonDorStatDto>>
    {
        public BallonDorStatDto BallonDorStatDto { get; set; }
    }

    public class UpdateBallonDorStatCommand : BaseRequest<CommandResponse>
    {
        public BallonDorStatDto BallonDorStatDto;
    }

    public class DeleteBallonDorStatCommand : BaseRequest<CommandResponse>
    {
        public Guid BallonDorStatId { get; set; }
    }
}
