

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    [Table("WinnersCupInfo")]
    public class TeamUefaWinnersCup
    {
        public Guid WinnersCupID { get; set; }

        public string Place { get; set; }
        public int Year { get; set; }
        public string Confederation { get; set; }

        [ForeignKey("WinnerTeam")]
        public Guid UefaWinnersCupWinnerId { get; set; }
        [ForeignKey("RunnerUpTeam")]
        public Guid UefaWinnersCupRunnerUpId { get; set; }

        [IgnoreDataMember]
        public Team WinnerTeam { get; set; }
        [IgnoreDataMember]
        public Team RunnerUpTeam { get; set; }
    }
}
