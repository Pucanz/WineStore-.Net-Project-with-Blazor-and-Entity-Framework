using System;
using System.ComponentModel.DataAnnotations;

namespace WineStore.Dtos;

public record class UpdateWineDto(
    [Required] string Name,
    string Winery,
    string Location,
    string Description,
    [Range(0, 1000)] decimal Price,
    [Range(0, 1000)] int Stock,
    int CategoryId,
    string Image
    
);

