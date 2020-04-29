using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTournamentProject.ServerApp.Database
{
    public class NameGenerator
    {
        private readonly string[] prefix = { "FC", "Alianza", "Sporting", "Atletico" };
        private readonly string[] city = { "São Paulo", "Amsterdam", "Florence", "Rosario", "San Francisco" };
        private readonly string[] postfix = { "United", "Wizards", "Universidade" };

        private readonly Random rand = new Random();

        public string GetTeamName()
        {
            string team = "";

            bool useprefix = rand.NextDouble() > 0.5;
            if (useprefix) team += prefix[rand.Next(prefix.Length)] + " ";
            team += city[rand.Next(city.Length)];
            if (!useprefix) team += " " + postfix[rand.Next(postfix.Length)];

            return team;
        }

        string getFirstName()
        {
            return "";
        }

        string getLastName()
        {
            return "";
        }
    }
}
