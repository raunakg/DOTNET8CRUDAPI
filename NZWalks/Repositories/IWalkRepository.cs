using System;
using NZWalks.Models.Domain;

namespace NZWalks.Repositories;

public interface IWalkRepository
{
    Task<Walk> CreateWalkAsync(Walk walk);

    Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
    string? sortBy = null, bool isAscending = true);

    Task<Walk?> GetByIdAsync(Guid id);

    Task<Walk?> UpdateAsync(Guid id, Walk walk);

    Task<Walk?> DeleteAsync(Guid id);


}
