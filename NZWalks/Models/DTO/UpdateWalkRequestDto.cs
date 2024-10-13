using System;

namespace NZWalks.Models.DTO;

public class UpdateWalkRequestDto
{

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required double LengthInKm { get; set; }

    public string? WalkImageUrl { get; set; }

    public Guid DifficultyId { get; set; }

    public Guid RegionId { get; set; }
}
