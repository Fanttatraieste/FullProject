using System.ComponentModel.DataAnnotations.Schema;


namespace RetroBack.Domain.Entities
{
    [Table("NationInfo")]
    public class Nation
    {
        public Guid NationID { get; set; }
        public string NationName { get; set; }

        public string Confederation { get; set; }

        public ICollection<NationIconStats> IconsStats { get; set; }

        public ICollection<NationWorldCup> WorldCups { get; set; }
        public ICollection<NationWorldCup> WorldCupRunnerUps { get; set; }
        public ICollection<NationWorldCup> WorldCupThirdPlaces { get; set; }
        public ICollection<WorldCupSquads> WorldCupSquads { get; set; }

        public ICollection<NationContinentalCup> ContinentalCups { get;  set; }
        public ICollection<NationContinentalCup> ContinentalCupRunnerUps { get; set; }
        public ICollection<NationContinentalCup> ContinentalCupThirdPlaces { get; set; }

        public ICollection<ContinentalCupSquads> ContinentalCupSquads { get; set; }

    }
}
