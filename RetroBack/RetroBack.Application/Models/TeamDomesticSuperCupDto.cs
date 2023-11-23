namespace RetroBack.Application.Models
{
    public class TeamDomesticSuperCupDto
    {
        public Guid DomesticSuperCupID { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public Guid WinnerId { get; set; }
        public string WinnerName { get; set;}
    }
}
