using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebTournamentProject.ServerApp.Models;

namespace WebTournamentProject.ServerApp.Database
{
    public class DatabaseEntityFramework : IDatabase
    {
        public string ImplementationVersion
        {
            get { return "EntityFramework";  }
        }


        public void CreateNewTeam(string name)
        {
            using (var ctx = new DataContext())
            {
                // name generator
                var team = new Team { Name = name };

                ctx.Teams.Add(team);
                ctx.SaveChanges();

                for (int i=0; i<5; i++)
                {
                    var player = new Player { FirstName = "Harry", LastName = "Wilson" };
                    player.TeamId = team.TeamId;
                    ctx.Players.Add(player);
                    team.Players.Add(player);
                }
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Team> GetAllTeams()
        {
            using (var ctx = new DataContext())
            {
                return ctx.Teams.ToArray();
            }
        }

        public Team GetTeam(int id)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Teams.Single(x => x.TeamId == id);
            }
        }

        public void StoreMatchResult(int teamId1, int teamId2, int score1, int score2)
        {
            using (var ctx = new DataContext())
            {
                var team1 = GetTeam(teamId1);
                var team2 = GetTeam(teamId2);

                // Create results entry
                var result = new Result
                {
                    TeamName1 = team1.Name,
                    TeamName2 = team2.Name,
                    Score1 = score1,
                    Score2 = score2
                };

                ctx.Results.Add(result);
                ctx.SaveChanges();
            }
        }

        public TeamRanking GetRanking(int teamId)
        {
            using (var ctx = new DataContext())
            {
                var rank = ctx.Ranking.SingleOrDefault(x => x.TeamId == teamId);
                if (rank != null) return rank;

                // Create a new entry for the team in the ranking
                var team = GetTeam(teamId);
                var ranking = new TeamRanking { TeamId = teamId, Name = team.Name };
                ctx.Ranking.Add(ranking);
                ctx.SaveChanges();
                return ranking;
            }
        }

        public bool TeamExists(string name)
        {
            using (var ctx = new DataContext())
            {
                return ctx.Teams.Any(x => x.Name == name);
            }
        }

        public IEnumerable<Result> GetAllResults()
        {
            using (var ctx = new DataContext())
            {
                return ctx.Results.ToArray();
            }
        }

        public List<TeamRanking> GetAllRankings()
        {
            using (var ctx = new DataContext())
            {
                return ctx.Ranking.ToList();
            }
        }

        public bool UpdateRanking(TeamRanking ranking)
        {
            using (var ctx = new DataContext())
            {
                var rank = ctx.Ranking.SingleOrDefault(x => x.TeamId == ranking.TeamId);
                if (rank != null)
                {
                    // Update DB record
                    rank.Games  = ranking.Games;
                    rank.Points = ranking.Points;
                    rank.Goals  = ranking.Goals;
                    rank.Rank   = ranking.Rank;

                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
