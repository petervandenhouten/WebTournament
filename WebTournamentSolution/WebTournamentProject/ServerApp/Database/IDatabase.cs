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
        //public Team         GetTeams(int id);

    }
}
