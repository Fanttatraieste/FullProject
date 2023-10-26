using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Common.Constants
{
    public static class ErrorMessages
    {
        public const string API_UserLoginCommand_DisabledUser = "This user is disabled by administrator";
        public const string API_UserLoginCommand_InvalidUserInformation = "Incorrect username and/or password";
        public const string Team_Does_Not_Exist = "Team does not exist";
        public const string ChampionsCup_Does_Not_Exist = "Champions Cup does not exist";
        public const string DomesticCup_Does_Not_Exist = "Domestic Cup does not exist";
        public const string DomesticLeague_Does_Not_Exist = "Domestic League does not exist";
    }
}
