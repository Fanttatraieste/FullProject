
using RetroBack.Application.Common;
using RetroBack.Application.Models;

namespace RetroBack.Application.Commands.TeamCommands
{
    public class CreateTeamCommand : BaseRequest<CommandResponse<TeamDTO>>
    {
        public TeamDTO TeamDTO { get; set; }
    }

    public class UpdateTeamCommand : BaseRequest<CommandResponse>
    {
        public TeamDTO TeamDTO { set; get; }
    }

    public class DeleteTeamCommand : BaseRequest<CommandResponse>
    {
        public Guid TeamID { get; set; }
    }
}
