using RetroBack.Application.Common;
using RetroBack.Application.Models;


namespace RetroBack.Application.Commands.NationCommands
{
    public class CreateNationCommand : BaseRequest<CommandResponse<NationDto>>
    {
        public NationDto NationDto { get; set; }
    }

    public class UpdateNationCommand : BaseRequest<CommandResponse>
    {
        public NationDto NationDto { get; set; }
    }

    public class DeleteNationCommand : BaseRequest<CommandResponse>
    {
        public Guid NationId { get; set; }
    }
}
