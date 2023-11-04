using RetroBack.Domain.Entities;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static class NationMapper
    {
        public static IQueryable<NationListItemDto> ProjectToDto(this IQueryable<Nation> nationQuery)
        {
            return nationQuery.Select(x => new NationListItemDto
            {
                NationId = x.NationID,
                NationName = x.NationName,
                Confederation = x.Confederation,
            });
        }
    }
}
