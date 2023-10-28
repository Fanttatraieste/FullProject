using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    public class ContinentalCupSquads
    {
        public Guid SquadId { get; set; }
        public int Year { get; set; }

        [ForeignKey("Nation")]
        public Guid NationId { get; set; }

        [IgnoreDataMember]
        public Nation Nation { get; set; }

        public ICollection<NationIconStatsContinentalCupSquads> Players { get; set; }
    }
}
