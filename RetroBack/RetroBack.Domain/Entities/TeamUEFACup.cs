using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    [Table("UEFACupInfo")]
    public class TeamUEFACup
    {
        public Guid UEFACupID { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
        public string Confederation { get; set; }

        [ForeignKey("WinnerTeam")]
        public Guid UefaCupWinnerId { get; set; }

        [ForeignKey("RunnerUpTeam")]
        public Guid UefaCupRunnerUpId { get; set; }

        [IgnoreDataMember]
        public Team WinnerTeam { get; set; }
        [IgnoreDataMember]
        public Team RunnerUpTeam { get; set; }
    }
}
