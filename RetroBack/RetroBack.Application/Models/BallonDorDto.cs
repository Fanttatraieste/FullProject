
namespace RetroBack.Application.Models
{
    public class BallonDorDto
    {
        public Guid BallonDorId { get; set; }
        public int Year { get; set; }
        public Guid WinnerIconId { get; set; }
        public string WinnerIconName { get; set; }
        public Guid RunnerUpIconId { get; set; }
        public string RunnerUpIconName { get; set; }
        public Guid ThirdPlaceIconId { get; set; }
        public string ThirdPlaceIconName { get; set; }
        public Guid FourthPlaceIconId { get; set; }
        public string FourthPlaceIconName { get; set; }
        public Guid FifthPlaceIconId { get; set; }
        public string FifthPlaceIconName { get; set; }
        public Guid SixthPlaceIconId { get; set; }
        public string SixthPlaceIconName { get; set; }
        public Guid SeventhPlaceIconId { get; set; }
        public string SeventhPlaceName { get; set; }
        public Guid EigthPlaceIconId { get; set; }
        public string EigthPlaceName { get; set; }
        public Guid NinethPlaceIconId { get; set; }
        public string NinethPlaceName { get; set; }
        public Guid TenthPlaceIconId { get; set; }
        public string TenthPlaceIconName { get; set; }
        public List<IconPairNameDto> Nominations { get; set; }
    }
}
