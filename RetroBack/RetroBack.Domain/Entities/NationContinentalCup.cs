

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RetroBack.Domain.Entities
{
    public class NationContinentalCup
    {
        public Guid ContinentalCupID { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
        public string Confederation { get; set; }

        [ForeignKey("WinnerNation")]
        public Guid WinnerNationId { get; set; }
        [ForeignKey("RunnerUpNation")]
        public Guid RunnerUpNationId { get; set; }
        [ForeignKey("ThirdPlaceNation")]
        public Guid? ThirdPlaceNationId { get; set; }

        [IgnoreDataMember]
        public Nation WinnerNation { get; set; }
        [IgnoreDataMember]
        public Nation RunnerUpNation { get; set; }
        [IgnoreDataMember]
        public Nation ThirdPlaceNation { get; set; }

    }
}
