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
    public class TableController : ControllerBase
    {
        // Retrieve the list of all teams
        // GET: api/Table
        [HttpGet]
        public IEnumerable<TeamRanking> Get()
        {
            var list = new List<TeamRanking>();

            list.Add(new TeamRanking { Rank = 1, Name = "Team", Games = 1, Points = 3 });
            list.Add(new TeamRanking { Rank = 2, Name = "Team", Games = 1, Points = 0 });

            return list.AsEnumerable();
        }

    }
}