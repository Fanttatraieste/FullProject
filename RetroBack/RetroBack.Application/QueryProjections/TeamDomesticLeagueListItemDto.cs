
namespace RetroBack.Application.QueryProjections
{
    public class TeamDomesticLeagueListItemDto
    {
        public Guid DomesticLeagueID { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public Guid WinnerId { get; set; }
        public Guid RunnerUpId { get; set; }
        public string WinnerTeam { get; set; }
        public string RunnerUpTeam { get; set; }
    }
}
