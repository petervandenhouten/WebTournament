using System.Collections.Generic;

using WebTournamentProject.ServerApp.Models;

namespace WebTournamentProject.ServerApp.Database
{
    public interface IDatabase
    {
        public string ImplementationVersion { get; }

        // TEAMS
        public void                 CreateNewTeam       (string name);
        public IEnumerable<Team>    GetAllTeams         ();
        public bool                 TeamExists(string name);
        public Team                 GetTeam(int id);

        // MATCH RESULTS
        public void StoreMatchResult(int team1, int teams2, int score1, int score2);

        public IEnumerable<Result> GetAllResults();

        // RANKING
        public TeamRanking GetRanking(int teamId);

        public List<TeamRanking> GetAllRankings();

        public bool UpdateRanking (TeamRanking ranking);

    }
}
