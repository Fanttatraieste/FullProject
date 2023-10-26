using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace RetroBack.Domain.Entities
{
    [Table("DomesticCupInfo")]
    public class TeamDomesticCup
    {
        public Guid DomesticCupID { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        [ForeignKey("WinnerTeam")]
        public Guid WinnerId { get; set; }
        [IgnoreDataMember]
        public Team WinnerTeam { get; set; }
    }
}
