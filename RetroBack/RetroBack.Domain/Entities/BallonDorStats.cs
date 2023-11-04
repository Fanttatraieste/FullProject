using System.ComponentModel.DataAnnotations.Schema;

namespace RetroBack.Domain.Entities
{
    public class BallonDorStats
    {
        public Guid StatId { get; set; }

        [ForeignKey("Icon")]
        public Guid IconId { get; set; }
        public virtual Icon Icon { get; set; }

        public virtual ICollection<BallonDor> BallonDorWins { get; set; }
        public virtual ICollection<BallonDor> BallonDorSeconPlaces { get; set; }
        public virtual ICollection<BallonDor> BallonDorThirdPlaces { get; set; }
        public virtual ICollection<BallonDor> BallonDorFourthPlaces { get; set; }
        public virtual ICollection<BallonDor> BallonDorFifthPlaces { get; set; }
        public virtual ICollection<BallonDor> BallonDorSixthPlaces { get; set; }
        public virtual ICollection<BallonDor> BallonDorSeventhPlaces { get; set; }
        public virtual ICollection<BallonDor> BallonDorEigthPlaces { get; set; }
        public virtual ICollection<BallonDor> BallonDorNinethPlaces { get; set; }
        public virtual ICollection<BallonDor> BallonDorTenthPlaces { get; set; }
        public virtual ICollection<BallonDorNominationsStats> BallonDorNominations { get; set; }
    }
}
