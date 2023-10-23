using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections;
using RetroBack.Application.QueryProjections.Mappers;
using RetroBack.Common.Constants;
using RetroBack.Common.Extentions;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Queries.TeamQueries
{
    public class TeamQueryHandler : IRequestHandler<GetTeamQuery, CommandResponse<TeamDTO>>, IRequestHandler<GetTeamsQuery, CollectionResponse<TeamListItemDTO>>
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamQueryHandler(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<CommandResponse<TeamDTO>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var existingTeam = await _teamRepository.Query(t => t.TeamID == request.TeamID).Select(t => new TeamDTO
            {
                TeamID = t.TeamID,
                TeamCountry = t.TeamCountry,
                TeamName = t.TeamName,
            })
            .FirstOrDefaultAsync();

           if (existingTeam == null)
            {
                return CommandResponse<TeamDTO>.Failed(ErrorMessages.Team_Does_Not_Exist);
            }

           return CommandResponse<TeamDTO>.Ok(existingTeam);
        }

        public async Task<CollectionResponse<TeamListItemDTO>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            if (request.Skip < 0)
                request.Skip = 0;

            if (request.Take <= 0 || request.Take > 20)
                request.Take = 20;

            var teamsQuery = _teamRepository.Query();

            // filtering 
            teamsQuery = teamsQuery.ApplyFilter(request);

            // count total number of records
            var totalNumberOfRecords = await teamsQuery.CountAsync();

            // projection
            var teamsDtoQuery = teamsQuery.ProjectToDTO();

            // sorting
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                teamsDtoQuery = teamsDtoQuery.OrderByField(request.SortBy, request.SortDir);
            }

            // pagination
            teamsDtoQuery = teamsDtoQuery.Skip(request.Skip).Take(request.Take);

            var existingTeamsDtos = await teamsDtoQuery.ToListAsync();
            return new CollectionResponse<TeamListItemDTO>(existingTeamsDtos, totalNumberOfRecords);
        }
    }
}
