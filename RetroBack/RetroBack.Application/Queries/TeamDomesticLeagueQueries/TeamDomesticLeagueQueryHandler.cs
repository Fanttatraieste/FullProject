using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.QueryProjections;
using RetroBack.Application.QueryProjections.Mappers;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Queries.TeamDomesticLeagueQueries
{
    public class TeamDomesticLeagueQueryHandler : 
        IRequestHandler<GetDomesticLeagueQuery, CommandResponse<TeamDomesticLeagueListItemDto>>,
        IRequestHandler<GetDomesticLeaguesQuery, CollectionResponse<TeamDomesticLeagueListItemDto>>
    {
        private readonly IRepository<TeamDomesticLeague> _leagueRepository;
        public TeamDomesticLeagueQueryHandler(IRepository<TeamDomesticLeague> leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        public async Task<CommandResponse<TeamDomesticLeagueListItemDto>> Handle(GetDomesticLeagueQuery request, CancellationToken cancellationToken)
        {
            var existingLeague = await _leagueRepository.Query(l => l.DomesticLeagueID == request.LeagueId).Select(l => new TeamDomesticLeagueListItemDto
            {
                DomesticLeagueID = l.DomesticLeagueID,
                Year = l.Year,
                Country = l.Country,
                WinnerId = l.WinnerId,
                RunnerUpId = l.RunnerUpId,
                WinnerTeam = l.WinnerTeam.TeamName,
                RunnerUpTeam = l.RunnerUpTeam.TeamName,
            }).FirstOrDefaultAsync(cancellationToken);

            if (existingLeague == null)
            {
                return CommandResponse<TeamDomesticLeagueListItemDto>.Failed(ErrorMessages.DomesticLeague_Does_Not_Exist);
            }

            return CommandResponse<TeamDomesticLeagueListItemDto>.Ok(existingLeague);
        }

        public async Task<CollectionResponse<TeamDomesticLeagueListItemDto>> Handle(GetDomesticLeaguesQuery request, CancellationToken cancellationToken)
        {
            if (request.Skip < 0)
                request.Skip = 0;

            if (request.Take <= 0 || request.Take > 20)
                request.Take = 20;

            var leagueQuery = _leagueRepository.Query();

            // filtering
            leagueQuery = leagueQuery.ApplyFilter(request); 

            // total records
            var totalRecords = await leagueQuery.CountAsync(cancellationToken);

            // projection
            var leagueDtoQuery = leagueQuery.ProjectToDto();

            leagueDtoQuery = leagueDtoQuery.Skip(request.Skip).Take(request.Take);

            var existingLeaguesDtos = await leagueDtoQuery.ToListAsync(cancellationToken);

            return new CollectionResponse<TeamDomesticLeagueListItemDto>(existingLeaguesDtos, totalRecords);
        }
    }
}
