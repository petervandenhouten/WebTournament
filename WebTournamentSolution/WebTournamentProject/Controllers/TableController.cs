using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using WebTournamentProject.ServerApp.Database;
using WebTournamentProject.ServerApp.Models;

namespace WebTournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IDatabase _db;
        public TableController(IDatabase db)
        {
            _db = db;
        }

        // Retrieve the list of rakings for teams, order by rank
        // GET: api/Table
        [HttpGet]
        public IEnumerable<TeamRanking> Get()
        {
            var ranking = _db.GetAllRankings() ;
            return ranking.OrderBy(x => x.Rank);
            //return ranking;
        }

    }
}