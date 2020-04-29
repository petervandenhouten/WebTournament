using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTournamentProject.ServerApp.Models
{
    public class TeamRanking
    {
        public int TeamRankingId { get; set; } // Primairy key by convention
        public int Rank { get; set; } 
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int Games { get; set; }
        public int Points { get; set; }
        public int Goals { get; set; }

    }

    public class RankingCompare : IComparer<TeamRanking>
    {
        public int Compare(TeamRanking rank1, TeamRanking rank2)
        {
            if (rank1 == null || rank2 == null)
            {
                return 0;
            }

            if (rank1.Points > rank2.Points)
            {
                return -1;
            }
            else if (rank2.Points > rank1.Points)
            {
                return 1;
            }
            else if (rank1.Games < rank2.Games)
            {
                return -1;
            }
            else if (rank2.Games < rank1.Games)
            {
                return 1;
            }
            else if (rank1.Goals > rank2.Goals)
            {
                return -1;
            }
            else if (rank2.Goals > rank1.Goals)
            {
                return 1;
            }

            return 0;
        }
    }
}
