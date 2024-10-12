using System;

namespace NZWalks.Models.DTO;

public class AddRegionRequestDto
{
    public required string Code { get; set; }

    public required string Name { get; set; }

    public string? RegionImageUrl { get; set; }
}
