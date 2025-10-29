using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data

{
    public class NZWalksDbContext: DbContext
    {
       public NZWalksDbContext(DbContextOptions dbContextOptions ): base(dbContextOptions)
        {
        }

        public DbSet<Region> Regions  { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
       
        public DbSet<Walk> Walks { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints using Fluent API if needed
            //seed data for Difficulties
            // easy, medium, hard
            modelBuilder.Entity<Difficulty>().HasData(
                new Difficulty
                {
                    Id = Guid.Parse("5420d83f-e63e-4981-b768-d67935b9c7e1"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("494667ce-47b6-4544-9c8a-0fa7e4db7ff1"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("1cff7579-3a13-4fba-8d9c-1e22c9e57db1"),
                    Name = "Hard"
                }
            );

            //seed data for Regions

        }



    }
}
