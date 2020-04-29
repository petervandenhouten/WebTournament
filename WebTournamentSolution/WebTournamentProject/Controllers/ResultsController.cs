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
    public class ResultsController : ControllerBase
    {
        // Retrieve the list of all teams
        // GET: api/Results
        [HttpGet]
        public IEnumerable<Result> Get()
        {
            var list = new List<Result>();

            list.Add(new Result { TeamName1 = "Team", Score1 = 1, TeamName2 = "Team", Score2 = 2 });

            return list.AsEnumerable();
        }
    }
}