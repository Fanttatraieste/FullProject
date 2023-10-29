

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    public class BallonDorNominationsStats
    {
        [ForeignKey("BallonDor")]
        public Guid BallonId { get; set; }
        [ForeignKey("BallonDorStats")]
        public Guid BallonStatId { get; set; }

        [IgnoreDataMember]
        public BallonDor BallonDor { get; set; }
        [IgnoreDataMember]
        public BallonDorStats BallonDorStats { get; set; }
    }
}
