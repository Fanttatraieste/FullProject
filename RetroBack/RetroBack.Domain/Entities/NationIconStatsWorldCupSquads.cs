

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    public class NationIconStatsWorldCupSquads
    {
        [ForeignKey("NationIconStats")]
        public Guid StatsId { get; set; }
        [ForeignKey("WorldCupSquads")]
        public Guid SquadId { get; set; }

        [IgnoreDataMember]
        public NationIconStats NationIconStats { get; set; }
        [IgnoreDataMember]
        public WorldCupSquads WorldCupSquads { get; set;}
    }
}
