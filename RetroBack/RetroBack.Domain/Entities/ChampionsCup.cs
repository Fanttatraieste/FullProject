using RetroBack.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FootballIconsCAPI.Entities
{
    [Table("ChampionsCupInfo")]
    public class ChampionsCup
    {
        public Guid ChampionsCupID { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
        public string Confederation { get; set; }


        [ForeignKey("Winner")]
        public Guid WinnerTeamId { get; set; }
        [ForeignKey("RunnerUp")]
        public Guid RunnerUpTeamId { get; set; }

        [IgnoreDataMember]
        public Team Winner {  get; set; }
        [IgnoreDataMember]
        public Team RunnerUp { get; set; }
    }
}