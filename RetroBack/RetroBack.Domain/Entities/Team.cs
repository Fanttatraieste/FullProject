using FootballIconsCAPI.Entities;

namespace RetroBack.Domain.Entities
{
    public class Team
    {
        public Guid TeamID { get; set; }
        public string TeamName { get; set; }
        public string  TeamCountry { get; set; }

        public virtual ICollection<TeamIconStats> IconStats { get; set; }

        public virtual ICollection<ChampionsCup> ChampionsCups { get; set; }
        public virtual ICollection<ChampionsCup> ChampionsCupRunnerUps { get; set; }
        public virtual ICollection<TeamDomesticCup> DomesticCups { get; set; }
        public virtual ICollection<TeamDomesticLeague> DomesticLeagues { get; set; }
        public virtual ICollection<TeamDomesticLeague> DomesticLeagueRunnerUps { get; set; }
        public virtual ICollection<TeamDomesticSuperCup> DomesticSuperCups { get; set; }
        public virtual ICollection<TeamUEFACup> UefaCups { get; set; }
        public virtual ICollection<TeamUEFACup> UefaCupsRunnerUps { get; set; }
        public virtual ICollection<TeamUefaSuperCup> UefaSuperCups { get; set; }
        public virtual ICollection<TeamUefaWinnersCup> UefaWinnersCups { get; set; }
        public virtual ICollection<TeamUefaWinnersCup> UefaWinnersCupRunnerUps { get; set; }
    }
}
