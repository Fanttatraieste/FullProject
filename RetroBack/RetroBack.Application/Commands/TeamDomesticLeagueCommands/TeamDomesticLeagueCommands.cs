
using RetroBack.Application.Common;
using RetroBack.Application.Models;

namespace RetroBack.Application.Commands.TeamDomesticLeagueCommands
{
    public class CreateTeamDomesticLeagueCommand : BaseRequest<CommandResponse<TeamDomesticLeagueDto>>
    {
        public TeamDomesticLeagueDto TeamDomesticLeagueDto { get; set; }
    }

    public class UpdateTeamDomesticLeagueCommand : BaseRequest<CommandResponse>
    {
        public TeamDomesticLeagueDto TeamDomesticLeagueDto { get; set; }
    }

    public class DeleteTeamDomesticLeagueCommand : BaseRequest<CommandResponse>
    {
        public Guid LeagueId { get; set; }
    }
}
