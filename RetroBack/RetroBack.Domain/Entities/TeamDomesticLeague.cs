using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    [Table("DomesticLeagueInfo")]
    public  class TeamDomesticLeague
    {
        public Guid DomesticLeagueID { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        [ForeignKey("WinnerTeam")]
        public Guid WinnerId { get; set; }
        [ForeignKey("RunnerUpTeam")]
        public Guid RunnerUpId { get; set; }

        [IgnoreDataMember]
        public Team WinnerTeam { get; set; }
        [IgnoreDataMember]
        public Team RunnerUpTeam { get; set; }
    }
}
