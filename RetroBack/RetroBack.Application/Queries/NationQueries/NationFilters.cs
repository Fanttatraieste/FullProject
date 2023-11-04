using RetroBack.Domain.Entities;

namespace RetroBack.Application.Queries.NationQueries
{
    public static class NationFilters
    {
        public static IQueryable<Nation> ApplyFilter(this IQueryable<Nation> nationsQuery, GetNationsQuery request)
        {
            if (!string.IsNullOrEmpty(request.NationName))
                nationsQuery = nationsQuery.Where(n => n.NationName.Contains(request.NationName));

            if (!string.IsNullOrEmpty(request.Confederation))
                nationsQuery = nationsQuery.Where(n => n.Confederation.Contains(request.Confederation));

            return nationsQuery;
        }
    }
}
