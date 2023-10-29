using RetroBack.Application.QueryProjections;
using RetroBack.Domain.Entities;

namespace RetroBack.Application.Queries.NationQueries
{
    public static class NationFilter
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
