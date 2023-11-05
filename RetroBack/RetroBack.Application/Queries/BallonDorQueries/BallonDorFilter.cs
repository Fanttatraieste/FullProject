
using RetroBack.Domain.Entities;

namespace RetroBack.Application.Queries.BallonDorQueries
{
    public static class BallonDorFilter
    {
        public static IQueryable<BallonDor> ApplyFilter(this IQueryable<BallonDor> ballonDorQuery, GetBallonDorsQuery request)
        {
            if (request.Year != null && request.Year > 1955)
                ballonDorQuery = ballonDorQuery.Where(b => b.Year == request.Year);

            return ballonDorQuery;
        }
    }
}
