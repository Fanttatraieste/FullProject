using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    [Table("UEFASuperCupInfo")]
    public class TeamUefaSuperCup
    {
        public Guid UEFASuperCupID { get; set; }
        public string Place { get; set; }
        public string Confederation { get; set; }
        public int Year { get; set; }

        [ForeignKey("WinnerTeam")]
        public Guid UefaSuperCupWinnerId { get; set; }

        [IgnoreDataMember]
        public Team WinnerTeam { get; set; }
        
    }
}
