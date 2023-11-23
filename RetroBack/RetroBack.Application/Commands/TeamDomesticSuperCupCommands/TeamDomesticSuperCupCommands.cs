using RetroBack.Application.Common;
using RetroBack.Application.Models;

namespace RetroBack.Application.Commands.TeamDomesticSuperCupCommands
{
    public class CreateTeamDomesticSuperCupCommand: BaseRequest<CommandResponse<TeamDomesticSuperCupDto>>
    {
        public TeamDomesticSuperCupDto TeamDomesticSuperCupDto { get; set; }
    }

    public class UpdateTeamDomesticSuperCupCommand: BaseRequest<CommandResponse>
    {
        public TeamDomesticSuperCupDto TeamDomesticSuperCupDto { get; set; }
    }

    public class DeleteTeamDomesticSuperCupCommand: BaseRequest<CommandResponse>
    {
        public Guid DomesticSuperCupId { get; set; }
    }
}
