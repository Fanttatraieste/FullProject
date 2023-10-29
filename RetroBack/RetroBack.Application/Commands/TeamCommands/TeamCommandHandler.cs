using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Commands.TeamCommands
{
    public class TeamCommandHandler : 
        IRequestHandler<CreateTeamCommand, CommandResponse<TeamDTO>>,
        IRequestHandler<UpdateTeamCommand, CommandResponse>,
        IRequestHandler<DeleteTeamCommand, CommandResponse>
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamCommandHandler(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<CommandResponse<TeamDTO>> Handle (CreateTeamCommand request, CancellationToken cancellationToken)
        {
            request.TeamDTO.TeamID = Guid.NewGuid();

            var newTeam = new Team
            {
                TeamID = request.TeamDTO.TeamID,
                TeamName = request.TeamDTO.TeamName,
                TeamCountry = request.TeamDTO.TeamCountry
            };

            _teamRepository.Add(newTeam);

            await _teamRepository.SaveChangesAsync();

            return await Task.FromResult(CommandResponse<TeamDTO>.Ok(request.TeamDTO)); 
        }

        public async Task<CommandResponse> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var existingTeam = await _teamRepository.Query(e => e.TeamID == request.TeamDTO.TeamID).FirstOrDefaultAsync();

            if (existingTeam == null)
                return CommandResponse.Failed(ErrorMessages.Team_Does_Not_Exist);

            existingTeam.TeamName = request.TeamDTO.TeamName;
            existingTeam.TeamCountry = request.TeamDTO.TeamCountry;
            
          

            await _teamRepository.SaveChangesAsync();
            return CommandResponse.Ok();
        }

        public async Task<CommandResponse> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var existingEvent = await _teamRepository.Query(e => e.TeamID == request.TeamID).FirstOrDefaultAsync();
            if (existingEvent == null)
                return CommandResponse.Failed(ErrorMessages.Team_Does_Not_Exist);

            _teamRepository.Remove(existingEvent);
            await _teamRepository.SaveChangesAsync();

            return CommandResponse.Ok();
        }
    }
}
