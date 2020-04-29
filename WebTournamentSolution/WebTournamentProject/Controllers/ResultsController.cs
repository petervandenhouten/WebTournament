using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using WebTournamentProject.ServerApp.Database;
using WebTournamentProject.ServerApp.Models;

namespace WebTournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IDatabase _db;
        public ResultsController(IDatabase db)
        {
            _db = db;
        }

        // Retrieve the list of all teams
        // GET: api/Results
        [HttpGet]
        public IEnumerable<Result> Get()
        {
            return _db.GetAllResults();
        }
    }
}