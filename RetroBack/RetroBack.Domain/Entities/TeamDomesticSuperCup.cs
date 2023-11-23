using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    [Table("DomesticSuperCupInfo")]
    public class TeamDomesticSuperCup
    {
        public Guid DomesticSuperCupID { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        [ForeignKey("Winner")]
        public Guid WinnerId { get; set; }
        [IgnoreDataMember]
        public Team Winner { get; set; }
    }
}
