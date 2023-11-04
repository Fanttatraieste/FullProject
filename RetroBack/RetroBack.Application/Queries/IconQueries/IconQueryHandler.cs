using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Application.QueryProjections;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Application.QueryProjections.Mappers;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Queries.IconQueries
{
    public  class IconQueryHandler :
        IRequestHandler<GetIconQuery, CommandResponse<IconDto>>,
        IRequestHandler<GetIconsQuery, CollectionResponse<IconListItemDto>>
    {
        private readonly IRepository<Icon> _iconRepository;

        public IconQueryHandler(IRepository<Icon> iconRepository)
        {
            _iconRepository = iconRepository;
        }

        public async Task<CommandResponse<IconDto>> Handle(GetIconQuery request, CancellationToken cancellationToken)
        {
            var existingIcon = await _iconRepository.Query(i => i.IconId == request.IconId).Select(i => new IconDto
            {
                IconId = i.IconId,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Nickname = i.Nickname,
                Description = i.Description,
                YearOfBirth = i.YearOfBirth,
                CareerLengthInYears = i.CareerLengthInYears,
                RetiredInYear = i.RetiredInYear,
                CareerGames = i.CareerGames,
                CareerGoals = i.CareerGoals,
                Position = i.Position,
                IconCountry = i.NationIconStats.Nation.NationName
            }).FirstOrDefaultAsync(cancellationToken);

            if (existingIcon == null)
            {
                return CommandResponse<IconDto>.Failed(ErrorMessages.Icon_Does_Not_Exist);
            }

            return CommandResponse<IconDto>.Ok(existingIcon);
        }

        public async Task<CollectionResponse<IconListItemDto>> Handle(GetIconsQuery request, CancellationToken cancellationToken)
        {
            if (request.Skip < 0)
                request.Skip = 0;

            if (request.Take <= 0 || request.Take > 20)
                request.Take = 20;

            var iconQuery = _iconRepository.Query();

            // filtering
            iconQuery = iconQuery.ApplyFilter(request);

            // count total number of records
            var totalNumberOfRecords = await iconQuery.CountAsync(cancellationToken);

            // projection
            var iconsDtoQuery = iconQuery.ProjectToDto();

            iconsDtoQuery = iconsDtoQuery.Skip(request.Skip).Take(request.Take);

            var existingIconsDtos = await iconsDtoQuery.ToListAsync(cancellationToken);

            return new CollectionResponse<IconListItemDto>(existingIconsDtos, totalNumberOfRecords);
        }
    }
}
