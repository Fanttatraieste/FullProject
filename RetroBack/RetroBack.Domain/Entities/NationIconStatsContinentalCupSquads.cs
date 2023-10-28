using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace RetroBack.Domain.Entities
{
    public class NationIconStatsContinentalCupSquads
    {
        [ForeignKey("NationIconStats")]
        public Guid StatsId { get; set; }

        [ForeignKey("ContinentalCupSquads")]
        public Guid SquadId { get; set; }

        [IgnoreDataMember]
        public NationIconStats NationIconStats { get; set; }
        [IgnoreDataMember]
        public ContinentalCupSquads ContinentalCupSquads { get; set; }
    }
}
