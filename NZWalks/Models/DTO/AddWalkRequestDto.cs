using System;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO;

public class AddWalkRequestDto
{

    [Required]
    [MaxLength(100, ErrorMessage = "Name must be at most 100 characters long.")]
    public required string Name { get; set; }

    [Required]
    [MaxLength(1000, ErrorMessage = "Description must be at most 1000 characters long.")]
    public required string Description { get; set; }

    [Required]
    [Range(0, 50, ErrorMessage = "Length must be between 0 and 50 km.")]
    public required double LengthInKm { get; set; }

    public string? WalkImageUrl { get; set; }

    [Required]
    public Guid DifficultyId { get; set; }

    [Required]
    public Guid RegionId { get; set; }
}
