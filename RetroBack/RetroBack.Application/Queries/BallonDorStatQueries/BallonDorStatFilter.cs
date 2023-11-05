using RetroBack.Domain.Entities;

namespace RetroBack.Application.Queries.BallonDorStatQueries
{
    public static class BallonDorStatFilter
    {
        public static IQueryable<BallonDorStats> ApplyFilter(this IQueryable<BallonDorStats> ballonDorStatsQuery, GetBallonDorStatsQuery request)
        {
            if (!string.IsNullOrEmpty(request.Nickname)) 
                ballonDorStatsQuery = ballonDorStatsQuery.Where(b => b.Icon.Nickname.Contains(request.Nickname));

            return ballonDorStatsQuery;
        }
    }
}
