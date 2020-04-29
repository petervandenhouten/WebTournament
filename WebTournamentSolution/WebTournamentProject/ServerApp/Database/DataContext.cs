using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebTournamentProject.ServerApp.Models;

namespace WebTournamentProject.ServerApp.Database
{
    // Use Entity framework with (file-based) SQLite
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {
//            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=webtournament.db");
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<TeamRanking> Ranking { get; set; }

    }
}
