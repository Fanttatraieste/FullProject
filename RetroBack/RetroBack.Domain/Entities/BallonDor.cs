using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

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

        [IgnoreDataMember]
        public BallonDorStats WinnerIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats RunnerUpIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats ThirdPlaceIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats FourthPlaceIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats FifthPlaceIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats SixthPlaceIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats SeventhPlaceIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats EigthPlaceIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats NinethPlaceIcon { get; set; }

        [IgnoreDataMember]
        public BallonDorStats TenthPlaceIcon { get; set; }

        public ICollection<BallonDorNominationsStats> Nominations { get; set; }
    }
}
