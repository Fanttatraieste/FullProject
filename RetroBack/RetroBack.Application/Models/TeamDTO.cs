using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Application.Models
{
    public class TeamDTO
    {
        public Guid TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamCountry { get; set; }
    }
}
