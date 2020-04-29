using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebTournamentProject.ServerApp.Models;

namespace WebTournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        // Retrieve the list of all teams
        // GET: api/Teams
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            var list = new List<Team>();

            list.Add(new Team { Name = "Team B" });
            list.Add(new Team { Name = "Team A" });

            return list;
        }

        // Retrieve the data of one teams
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
            int x = 0;
            return "name of new team";
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
