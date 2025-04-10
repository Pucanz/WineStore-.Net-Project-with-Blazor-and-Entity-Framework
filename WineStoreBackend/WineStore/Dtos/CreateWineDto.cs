using System.ComponentModel.DataAnnotations;

namespace WineStore.Dtos;

public record class CreateWineDto(

    int Id,
    [Required] string Name,
    string Winery,
    string Location,
    string Description,
    [Range(1, 1000)] decimal Price,
    [Range(1, 1000)] int Stock,
    int CategoryId,
    string Image

);
