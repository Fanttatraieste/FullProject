
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    public class TeamIconStats
    {
        public Guid StatId { get; set; }

        [ForeignKey("Icon")]
        public Guid IconId { get; set; }
        [ForeignKey("Team")]
        public Guid TeamId { get; set; }

        [IgnoreDataMember]
        public Icon Icon { get; set; }
        [IgnoreDataMember]
        public Team Team { get; set; }

        public int PlayedFromYear { get; set; }
        public int PlayedUntilYear { get; set; }

        public int GamesPlayed { get; set; }
        public int GoalsScored { get; set; }
    }
}
