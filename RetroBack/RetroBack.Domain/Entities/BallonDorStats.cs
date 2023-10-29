using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace RetroBack.Domain.Entities
{
    public class BallonDorStats
    {
        public Guid StatId { get; set; }

        [ForeignKey("Icon")]
        public Guid IconId { get; set; }
        [IgnoreDataMember]
        public Icon Icon { get; set; }

        public ICollection<BallonDor> BallonDorWins { get; set; }
        public ICollection<BallonDor> BallonDorSeconPlaces { get; set; }
        public ICollection<BallonDor> BallonDorThirdPlaces { get; set; }
        public ICollection<BallonDor> BallonDorFourthPlaces { get; set; }
        public ICollection<BallonDor> BallonDorFifthPlaces { get; set; }
        public ICollection<BallonDor> BallonDorSixthPlaces { get; set; }
        public ICollection<BallonDor> BallonDorSeventhPlaces { get; set; }
        public ICollection<BallonDor> BallonDorEigthPlaces { get; set; }
        public ICollection<BallonDor> BallonDorNinethPlaces { get; set; }
        public ICollection<BallonDor> BallonDorTenthPlaces { get; set; }
        public ICollection<BallonDorNominationsStats> BallonDorNominations { get; set; }
    }
}
