
using RetroBack.Application.Common;
using RetroBack.Application.Models;

namespace RetroBack.Application.Commands.IconCommands
{
    public  class CreateIconCommand : BaseRequest<CommandResponse<IconDto>>
    {
        public IconDto IconDto { get; set; }
    }

    public class UpdateIconCommand : BaseRequest<CommandResponse>
    {
        public IconDto IconDto { get; set; }
    }

    public class DeleteIconCommand : BaseRequest<CommandResponse>
    {
        public Guid IconId { get; set; }
    }
}
