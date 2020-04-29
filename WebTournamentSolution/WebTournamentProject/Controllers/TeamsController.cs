using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebTournamentProject.ServerApp.Models;
using WebTournamentProject.ServerApp.Database;

namespace WebTournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IDatabase _db;
        public TeamsController(IDatabase db)
        {
            _db = db;
        }

        // Retrieve the list of all teams
        // GET: api/Teams
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return _db.GetAllTeams();
        }

        // Retrieve the data of one team
        // GET: api/Teams/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "one team";
        }

        // Create a new team
        // POST: api/Teams/Create
        [HttpPost("create")]
        public string Create()
        {
            var generator = new NameGenerator();
            string newTeam = generator.GetTeamName();
            while (_db.TeamExists(newTeam))
            {
                newTeam = generator.GetTeamName();
            }
            _db.CreateNewTeam(newTeam);
            return newTeam;
        }

        // Update the team name
        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // Delete a team
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
