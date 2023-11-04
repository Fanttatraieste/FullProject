
using RetroBack.Domain.Entities;

namespace RetroBack.Application.Queries.IconQueries
{
    public static class IconFilter
    {
        public static IQueryable<Icon> ApplyFilter(this IQueryable<Icon> iconQuery, GetIconsQuery request)
        {
            if (!string.IsNullOrEmpty(request.Country))
                iconQuery = iconQuery.Where(i => i.NationIconStats.Nation.NationName.Contains(request.Country));
            
            if (!string.IsNullOrEmpty(request.FirstName))
                iconQuery = iconQuery.Where(i => i.FirstName.Contains(request.FirstName));

            if (!string.IsNullOrEmpty(request.LastName))
                iconQuery = iconQuery.Where(i => i.LastName.Contains(request.LastName));

            if (!string.IsNullOrEmpty(request.Nickname))
                iconQuery = iconQuery.Where(i => i.Nickname.Contains(request.Nickname));

            if (!string.IsNullOrEmpty(request.Position))
                iconQuery = iconQuery.Where(i => i.Position ==  request.Position);

            if (request.RetiredInYear != null)
                iconQuery = iconQuery.Where(i => i.RetiredInYear == request.RetiredInYear);

            return iconQuery;
        }
    }
}
