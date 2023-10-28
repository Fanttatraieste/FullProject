using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace RetroBack.Domain.Entities
{
    public class WorldCupSquads
    {
        public Guid SquadId { get; set; }


        public int Year;

        [ForeignKey("Nation")]
        public Guid NationId { get; set; }

        [IgnoreDataMember]
        public Nation Nation { get; set; }


        public ICollection<NationIconStatsWorldCupSquads> Players { get; set; }
    }
}
