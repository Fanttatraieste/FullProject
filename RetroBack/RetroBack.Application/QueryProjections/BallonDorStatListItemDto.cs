
namespace RetroBack.Application.QueryProjections
{
    public class BallonDorStatListItemDto
    {
        public Guid StatId { get; set; }
        public Guid IconID { get; set; }
        public string IconName { get; set; }
        public List<int> BallonDorWins { get; set; }
        public List<int> BallonDorRunnerUps { get; set; }
        public List<int> BallonDorThirdPlaces { get; set; }
        public List<int> BallonDorFourthPlaces { get; set; }
        public List<int> BallonDorFifthPlaces { get; set; }
        public List<int> BallonDorSixthPlaces { get; set; }
        public List<int> BallonDorSeventhPlaces { get; set; }
        public List<int> BallonDorEigthPlaces { get; set; }
        public List<int> BallonDorNinethPlaces { get; set; }
        public List<int> BallonDorTenthPlaces { get; set; }
        public List<int> BallonDorNominations { get; set; }

    }
}
