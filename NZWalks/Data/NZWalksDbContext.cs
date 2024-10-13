using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data;

public class NZWalksDbContext : DbContext
{
    public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Difficulty> Difficulties { get; set; }

    public DbSet<Region> Regions { get; set; }

    public DbSet<Walk> Walks { get; set; }


    // dotnet-ef migrations add "Seedimg data for difficulties and regions"
    // dotnet-ef database update  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        var difficulties = new List<Difficulty>()
        {
            new Difficulty { Id = Guid.Parse("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"), Name = "Easy" },
            new Difficulty { Id = Guid.Parse("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c"), Name = "Moderate" },
            new Difficulty { Id = Guid.Parse("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3d"), Name = "Hard" }

        };

        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions = new List<Region>()
        {
            new Region { Id = Guid.Parse("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3e"), Code = "N", Name = "Northland", RegionImageUrl = "northland.jpg" },
            new Region { Id = Guid.Parse("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3f"), Code = "A", Name = "Auckland", RegionImageUrl = "auckland.jpg" },
            new Region { Id = Guid.Parse("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b30"), Code = "W", Name = "Waikato", RegionImageUrl = "waikato.jpg" }, // Corrected
            new Region { Id = Guid.Parse("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b31"), Code = "B", Name = "Bay of Plenty", RegionImageUrl = "bayofplenty.jpg" }, // Corrected
            new Region { Id = Guid.Parse("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b32"), Code = "T", Name = "Taranaki", RegionImageUrl = "taranaki.jpg" } // Corrected
        };

        modelBuilder.Entity<Region>().HasData(regions);
    }
}
