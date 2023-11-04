using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections;
using RetroBack.Common.Constants;
using RetroBack.Domain.Repositories;
using RetroBack.Domain.Entities;
using RetroBack.Application.QueryProjections.Mappers;

namespace RetroBack.Application.Queries.NationQueries
{
    public class NationQueryHandler :
        IRequestHandler<GetNationQuery, CommandResponse<NationDto>>,
        IRequestHandler<GetNationsQuery, CollectionResponse<NationListItemDto>>
    {
        private readonly IRepository<Nation> _nationRepository;

        public NationQueryHandler(IRepository<Nation> nationRepository)
        {
            _nationRepository = nationRepository;
        }


        public async Task<CommandResponse<NationDto>> Handle(GetNationQuery request, CancellationToken cancellationToken)
        {
            var existingNation = await _nationRepository.Query(n => n.NationID == request.NationId).Select(n => new NationDto
            {
                NationId = n.NationID,
                NationName = n.NationName,
                Confederation = n.Confederation,
            })
            .FirstOrDefaultAsync(cancellationToken);

            if (existingNation == null)
            {
                return CommandResponse<NationDto>.Failed(ErrorMessages.Nation_Does_Not_Exist);
            }

            return CommandResponse<NationDto>.Ok(existingNation);
        }

        public async Task<CollectionResponse<NationListItemDto>> Handle(GetNationsQuery request, CancellationToken cancellationToken)
        {
            if (request.Skip < 0) 
                request.Skip = 0;

            if (request.Take <= 0 || request.Take > 20)
                request.Take = 20;

            var nationsQuery = _nationRepository.Query();

            // filtering 
            nationsQuery = nationsQuery.ApplyFilter(request);

            // count total number of records
            var totalNumberOfRecords = await nationsQuery.CountAsync(cancellationToken);

            // projection
            var nationsDtoQuery = nationsQuery.ProjectToDto();

            nationsDtoQuery = nationsDtoQuery.Skip(request.Skip).Take(request.Take);

            var existingNationsDtos = await nationsDtoQuery.ToListAsync(cancellationToken);

            return new CollectionResponse<NationListItemDto>(existingNationsDtos, totalNumberOfRecords);
        }
    }
}
