using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTournamentProject.ServerApp.Models
{
    public class TeamRanking
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public int Games { get; set; }
        public int Points { get; set; }

    }
}
