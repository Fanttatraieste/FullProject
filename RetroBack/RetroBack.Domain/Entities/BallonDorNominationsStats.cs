

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

        
        public virtual BallonDor BallonDor { get; set; }
        
        public virtual BallonDorStats BallonDorStats { get; set; }
    }
}
