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

    public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
     string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10)
    {
        // return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        var walks = _dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

        // Filter the walks
        if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
        {
            switch (filterOn.ToLower())
            {
                case "name":
                    walks = walks.Where(w => w.Name.Contains(filterQuery));
                    break;
                case "description":
                    walks = walks.Where(w => w.Description.Contains(filterQuery));
                    break;
            }
        }

        // Sort the walks
        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    walks = isAscending ? walks.OrderBy(w => w.Name) : walks.OrderByDescending(w => w.Name);
                    break;
                case "lengthinkm":
                    walks = isAscending ? walks.OrderBy(w => w.LengthInKm) : walks.OrderByDescending(w => w.LengthInKm);
                    break;
            }
        }

        // Pagination

        walks = walks.Skip((pageNumber - 1) * pageSize).Take(pageSize);


        return await walks.ToListAsync();


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
