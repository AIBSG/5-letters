using System;
using _5letters.Models;
using Microsoft.EntityFrameworkCore;

namespace _5letters.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CorrectWord> CorrectWords { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Letter> Letters { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //Database.EnsureCreated();
        }
        
    }
}
