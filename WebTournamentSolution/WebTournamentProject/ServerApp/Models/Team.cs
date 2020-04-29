using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTournamentProject.ServerApp.Models
{
    public class Team
    {
        public int TeamId { get; set; } // primary KEY by convention
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
