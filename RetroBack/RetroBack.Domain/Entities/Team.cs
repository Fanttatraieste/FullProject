using FootballIconsCAPI.Entities;

namespace RetroBack.Domain.Entities
{
    public class Team
    {
        public Guid TeamID { get; set; }
        public string TeamName { get; set; }
        public string  TeamCountry { get; set; }

        public ICollection<ChampionsCup> ChampionsCups { get; set; }
        public ICollection<ChampionsCup> ChampionsCupRunnerUps { get; set; }
        public ICollection<TeamDomesticCup> DomesticCups { get; set; }
        public ICollection<TeamDomesticLeague> DomesticLeagues { get; set; }
        public ICollection<TeamDomesticLeague> DomesticLeagueRunnerUps { get; set; }
    }
}
