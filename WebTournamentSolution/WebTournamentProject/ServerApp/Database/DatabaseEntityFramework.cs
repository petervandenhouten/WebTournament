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
    }
}
