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

            modelBuilder.Entity<Region>().HasData(
                new Region
                {
                    Id = Guid.Parse("a1f5c1e2-3b6d-4f8a-9f1e-1c2d3e4f5a6b"),
                    Name = "Nairobi",
                    Code = "NRB",
                    RegionImageUrl = "https://example.com/images/nairobi.jpg"
                    },
                new Region
                {
                    Id = Guid.Parse("b2e6d2f3-4c7e-5f9b-0g2h-2d3e4f5a6b7c"),
                    Name = "Mombasa",
                    Code = "MBA",
                    RegionImageUrl = "https://example.com/images/mombasa.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("c3f7e3g4-5h8i-6j0k-1l3m-3e4f5a6b7c8d"),
                    Name = "Kisumu",
                    Code = "KIS",
                    RegionImageUrl = "https://example.com/images/kisumu.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("d4g8h4i5-6j9k-7l1m-2n4o-4f5a6b7c8d9e"),
                    Name = "Nakuru",
                    Code = "NKU",
                    RegionImageUrl = "https://example.com/images/nakuru.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("e5h9i5j6-7k0l-8m2n-3o5p-5a6b7c8d9e0f"),
                    Name = "Eldoret",
                    Code = "ELD",
                    RegionImageUrl = "https://example.com/images/eldoret.jpg"
                }



            );

        }



    }
}
