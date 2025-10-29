﻿using Microsoft.EntityFrameworkCore;
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
                    Id = Guid.Parse("7503ec2d-3354-4c65-bfdc-b9727caf7dd5"),
                    Name = "Nairobi",
                    Code = "NRB",
                    RegionImageUrl = "https://example.com/images/nairobi.jpg"
                    },
                new Region
                {
                    Id = Guid.Parse("94dbd6b3-31f2-48ed-b7e9-02f5e74a660d"),
                    Name = "Mombasa",
                    Code = "MBA",
                    RegionImageUrl = "https://example.com/images/mombasa.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("0bb8403e-c4a6-410c-b2b1-117762a25b0d"),
                    Name = "Kisumu",
                    Code = "KIS",
                    RegionImageUrl = "https://example.com/images/kisumu.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("5a46ef1b-f149-4be4-b627-0c5832128326"),
                    Name = "Nakuru",
                    Code = "NKU",
                    RegionImageUrl = "https://example.com/images/nakuru.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("557fb860-ba91-46e2-b821-84433398319f"),
                    Name = "Eldoret",
                    Code = "ELD",
                    RegionImageUrl = "https://example.com/images/eldoret.jpg"
                }



            );

        }



    }
}
