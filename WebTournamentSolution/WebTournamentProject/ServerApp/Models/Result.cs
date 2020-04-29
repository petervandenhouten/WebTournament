using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebTournamentProject.ServerApp.Models
{
    public class Result
    {
        public int ResultId { get; set; } // primary KEY by convention
        public string TeamName1 { get; set; }
        public int Score1 { get; set; }
        public string TeamName2 { get; set; }
        public int Score2 { get; set; }
    }
}
