
namespace RetroBack.Application.Models
{
    public class TeamDomesticLeagueDto
    {
        public Guid DomesticLeagueID { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public Guid WinnerId { get; set; }
        public Guid RunnerUpId { get; set; }
    }
}
