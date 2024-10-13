using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private readonly NZWalksDbContext _dbContext;

    public SQLWalkRepository(NZWalksDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<Walk> CreateWalkAsync(Walk walk)
    {
        await _dbContext.Walks.AddAsync(walk);
        await _dbContext.SaveChangesAsync();
        return walk;
    }

    public async Task<List<Walk>> GetAllAsync()
    {
        return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();


    }

    public async Task<Walk?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
    {
        var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);

        if (existingWalk == null)
        {
            return null;
        }

        existingWalk.Name = walk.Name;
        existingWalk.Description = walk.Description;
        existingWalk.LengthInKm = walk.LengthInKm;
        existingWalk.WalkImageUrl = walk.WalkImageUrl;
        existingWalk.DifficultyId = walk.DifficultyId;
        existingWalk.RegionId = walk.RegionId;

        await _dbContext.SaveChangesAsync();

        return existingWalk;

    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
        var walk = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);

        if (walk == null)
        {
            return null;
        }

        _dbContext.Walks.Remove(walk);
        await _dbContext.SaveChangesAsync();

        return walk;
    }
}
