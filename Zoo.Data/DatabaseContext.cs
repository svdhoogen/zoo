using Microsoft.EntityFrameworkCore;
using Zoo.Core.Models;

namespace Zoo.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MigrationsHistory> MigrationsHistory { get; set; }

        public DbSet<Enclosure> Enclosures { get; set; }

        public DbSet<Zebra> Zebras { get; set; }
        public DbSet<Giraffe> Giraffes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}