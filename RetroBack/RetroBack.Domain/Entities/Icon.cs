

namespace RetroBack.Domain.Entities
{
    public class Icon
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
        public NationIconStats NationIconStats { get; set; }
        public BallonDorStats BallonDorStats { get; set; }
        public ICollection<TeamIconStats> TeamIconStats { get; set; }
    }
}
