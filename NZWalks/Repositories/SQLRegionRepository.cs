using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repositories;

public class SQLRegionRepository : IRegionRepository
{
    private readonly NZWalksDbContext _dbContext;
    public SQLRegionRepository(NZWalksDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Region> AddAsync(Region region)
    {
        await _dbContext.Regions.AddAsync(region);
        await _dbContext.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        var existingRegion = await _dbContext.Regions.FindAsync(id);

        if (existingRegion == null)
        {
            return null;
        }

        _dbContext.Regions.Remove(existingRegion);
        await _dbContext.SaveChangesAsync();

        return existingRegion;

    }

    public async Task<List<Region>> GetAllAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }

    public async Task<Region?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Regions.FindAsync(id);
    }

    public async Task<Region?> UpdateAsync(Guid id, Region region)
    {
        var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

        if (existingRegion == null)
        {
            return null;
        }

        existingRegion.Code = region.Code;
        existingRegion.Name = region.Name;
        existingRegion.RegionImageUrl = region.RegionImageUrl;

        await _dbContext.SaveChangesAsync();

        return existingRegion;
    }
}
