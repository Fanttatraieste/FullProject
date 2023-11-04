
namespace RetroBack.Application.Models
{
    public class IconDto
    {
        public Guid IconId { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Description { get; set; }
        public int CareerLengthInYears { get; set; }
        public int CareerGames { get; set; }
        public int CareerGoals { get; set; }
        public string Position { get; set; }
        public int RetiredInYear { get; set; }
        public int YearOfBirth { get; set; }
        public string IconCountry { get; set; }
    }
}
