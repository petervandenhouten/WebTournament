using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebTournamentProject.ServerApp.Database;
using WebTournamentProject.ServerApp.Models;

namespace WebTournamentProject.ServerApp.Game
{
    public class GameEngine
    {
        private readonly IDatabase _db;
        public GameEngine(IDatabase db)
        {
            _db = db;
        }

        public bool playMatch(int teamId1, int teamId2)
        {
            var team1 = _db.GetTeam(teamId1);
            var team2 = _db.GetTeam(teamId2);

            var rand = new Random();
            int score1 = rand.Next(5);
            int score2 = rand.Next(5);

            _db.StoreMatchResult(teamId1, teamId2, score1, score2);

            updateRanking(teamId1, teamId2, score1, score2);

            sortRanking();

            return true;
        }

        private void sortRanking()
        {
            var ranking = _db.GetAllRankings();

            var ranker = new RankingCompare();
            ranking.Sort(new RankingCompare());

            int i = 1;
            foreach(var rank in ranking )
            {
                rank.Rank = i++;
                _db.UpdateRanking(rank);
            }
        }

        private void updateRanking(int teamId1, int teamId2, int score1, int score2)
        {
            var ranking1 = _db.GetRanking(teamId1);
            var ranking2 = _db.GetRanking(teamId2);

            ranking1.Games++;
            ranking2.Games++;

            ranking1.Goals += score1;
            ranking2.Goals += score2;

            // Give points
            if (score1 > score2)
            {
                ranking1.Points += 3;
            }
            else if (score2 > score1)
            {
                ranking2.Points += 3;
            }
            else
            {
                ranking1.Points += 1;
                ranking2.Points += 1;
            }

            _db.UpdateRanking(ranking1);
            _db.UpdateRanking(ranking2);
        }
    }
}
