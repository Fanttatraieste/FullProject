using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Commands.TeamDomesticLeagueCommands
{
    public class TeamDomesticLeagueCommandHandler :
        IRequestHandler<CreateTeamDomesticLeagueCommand, CommandResponse<TeamDomesticLeagueDto>>,
        IRequestHandler<UpdateTeamDomesticLeagueCommand, CommandResponse>,
        IRequestHandler<DeleteTeamDomesticLeagueCommand, CommandResponse>
    {
        private readonly IRepository<TeamDomesticLeague> _leagueRepository;
        public TeamDomesticLeagueCommandHandler(IRepository<TeamDomesticLeague> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        public async Task<CommandResponse<TeamDomesticLeagueDto>> Handle(CreateTeamDomesticLeagueCommand request, CancellationToken cancellationToken)
        {
            request.TeamDomesticLeagueDto.DomesticLeagueID = Guid.NewGuid();

            var newLeague = new TeamDomesticLeague()
            {
                DomesticLeagueID = request.TeamDomesticLeagueDto.DomesticLeagueID,
                Country = request.TeamDomesticLeagueDto.Country,
                Year = request.TeamDomesticLeagueDto.Year,
                WinnerId = request.TeamDomesticLeagueDto.WinnerId,
                RunnerUpId = request.TeamDomesticLeagueDto.RunnerUpId,
            };

            _leagueRepository.Add(newLeague);

            await _leagueRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(CommandResponse<TeamDomesticLeagueDto>.Ok(request.TeamDomesticLeagueDto));
        }

        public async Task<CommandResponse> Handle(UpdateTeamDomesticLeagueCommand request, CancellationToken cancellationToken)
        {
            var existingLeague = await _leagueRepository.Query(t => t.DomesticLeagueID == request.TeamDomesticLeagueDto.DomesticLeagueID).FirstOrDefaultAsync(cancellationToken);

            if (existingLeague == null)
            {
                return CommandResponse.Failed(ErrorMessages.DomesticLeague_Does_Not_Exist);
            }

            existingLeague.Year = request.TeamDomesticLeagueDto.Year;
            existingLeague.WinnerId = request.TeamDomesticLeagueDto.WinnerId;
            existingLeague.RunnerUpId = request.TeamDomesticLeagueDto.RunnerUpId;
            existingLeague.Country = request.TeamDomesticLeagueDto.Country;

            await _leagueRepository.SaveChangesAsync(cancellationToken);
            return CommandResponse.Ok();
        }

        public async Task<CommandResponse> Handle(DeleteTeamDomesticLeagueCommand request, CancellationToken cancellationToken)
        {
            var existingLeague = await _leagueRepository.Query(t => t.DomesticLeagueID == request.LeagueId).FirstOrDefaultAsync(cancellationToken);

            if (existingLeague == null)
            {
                return CommandResponse.Failed(ErrorMessages.DomesticLeague_Does_Not_Exist);
            }

            _leagueRepository.Remove(existingLeague);

            await _leagueRepository.SaveChangesAsync(cancellationToken);
            return CommandResponse.Ok();
        }
    }
}
