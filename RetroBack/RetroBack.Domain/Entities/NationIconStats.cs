using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace RetroBack.Domain.Entities
{
    public class NationIconStats
    {
        public Guid StatId { get; set; }

        [ForeignKey("Icon")]
        public Guid IconId { get; set; }
        [ForeignKey("Nation")]
        public Guid NationId { get; set; }

        [IgnoreDataMember]
        public Icon Icon { get; set; }
        [IgnoreDataMember]
        public Nation Nation { get; set; }

        public int GamesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int WorldCupGoals { get; set; }

        public ICollection<NationIconStatsWorldCupSquads> WorldCupSquads { get; set; }  
        public ICollection<NationIconStatsContinentalCupSquads> ContinentalCupSquads {get; set; }
    }
}
