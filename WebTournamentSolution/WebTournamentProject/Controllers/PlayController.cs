using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using WebTournamentProject.ServerApp.Database;
using WebTournamentProject.ServerApp.Game;
using WebTournamentProject.ServerApp.Models;

namespace WebTournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : Controller
    {
        private readonly IDatabase _db;
        public PlayController(IDatabase db)
        {
            _db = db;
        }

        // Retrieve the list of all teams
        // GET: api/Play
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return _db.GetAllTeams();
        }

        // Post the teams to play the match. Teams must have 5 players.
        // Create a new team
        // POST: api/Play/{id}/{id}
        [HttpPost("match/{id1}/{id2}")]
        public string GetTeams2(int id1, int id2)
        {
            if (id1 == 0 || id2 ==0) return "Team ID cannot be 0";
            if (id2 == id1) return "Team ID's must be different";

            var game = new GameEngine(_db);

            if ( game.playMatch(id1, id2) )
            {

                return "Game played";
            }
            return "Error while playing match";
        }

    }
}
