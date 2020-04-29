using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTournamentProject.ServerApp.Models
{
    public class Player
    {
        public int PlayerId { get; set; } // primary KEY by convention
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int TeamId { get; set; }

//        [NotMapped]
    //    public string Name { get { return FirstName + " " + LastName; } }
    }
}
