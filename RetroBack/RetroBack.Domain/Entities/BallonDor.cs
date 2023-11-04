using System.ComponentModel.DataAnnotations.Schema;

namespace RetroBack.Domain.Entities
{
    public class BallonDor
    {
        public Guid BallonDorId { get; set; }
        public int Year { get; set; }

        [ForeignKey("WinnerIcon")]
        public Guid WinnerIconId { get; set; }

        [ForeignKey("RunnerUpIcon")]
        public Guid RunnerUpIconId { get; set; }

        [ForeignKey("ThirdPlaceIcon")]
        public Guid ThirdPlaceIconId { get; set; }

        [ForeignKey("FourthPlaceIcon")]
        public Guid FourthPlaceIconId { get; set; }

        [ForeignKey("FifthPlaceIcon")]
        public Guid FifthPlaceIconId { get; set; }

        [ForeignKey("SixthPlaceIcon")]
        public Guid SixthPlaceIconId { get; set; }

        [ForeignKey("SeventhPlaceIcon")]
        public Guid SeventhPlaceIconId { get; set; }

        [ForeignKey("EigthPlaceIcon")]
        public Guid EigthPlaceIconId { get; set; }

        [ForeignKey("NinethPlaceIcon")]
        public Guid NinethPlaceIconId { get; set; }

        [ForeignKey("TenthPlaceIcon")]
        public Guid TenthPlaceIconId { get; set; }

        public virtual BallonDorStats WinnerIcon { get; set; }
        public virtual BallonDorStats RunnerUpIcon { get; set; }
        public virtual BallonDorStats ThirdPlaceIcon { get; set; }
        public virtual BallonDorStats FourthPlaceIcon { get; set; }
        public virtual BallonDorStats FifthPlaceIcon { get; set; }
        public virtual BallonDorStats SixthPlaceIcon { get; set; }
        public virtual BallonDorStats SeventhPlaceIcon { get; set; }
        public virtual BallonDorStats EigthPlaceIcon { get; set; }
        public virtual BallonDorStats NinethPlaceIcon { get; set; }
        public virtual BallonDorStats TenthPlaceIcon { get; set; }
        public virtual ICollection<BallonDorNominationsStats> Nominations { get; set; }
    }
}
