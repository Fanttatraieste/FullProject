using RetroBack.Application.Common;
using RetroBack.Application.Models;

namespace RetroBack.Application.Commands.BallonDorCommands
{
    public class CreateBallonDorCommand : BaseRequest<CommandResponse<BallonDorDto>>
    {
        public BallonDorDto BallonDorDto { get; set;}
    }

    public class UpdateBallonDorCommand : BaseRequest<CommandResponse>
    {
        public BallonDorDto BallonDorDto;
    }

    public class DeleteBallonDorCommand : BaseRequest<CommandResponse>
    {
        public Guid BallonDorId { get; set; }
    }
}
