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
        public ICollection<TeamDomesticSuperCup> DomesticSuperCups { get; set; }
        public ICollection<TeamUEFACup> UefaCups { get; set; }
        public ICollection<TeamUEFACup> UefaCupsRunnerUps { get; set; }
        public ICollection<TeamUefaSuperCup> UefaSuperCups { get; set; }
        public ICollection<TeamUefaWinnersCup> UefaWinnersCups { get; set; }
        public ICollection<TeamUefaWinnersCup> UefaWinnersCupRunnerUps { get; set; }
    }
}
