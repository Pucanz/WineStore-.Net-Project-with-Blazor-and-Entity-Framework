using WineStore.Dtos;
using WineStore.Entities;

namespace WineStore.Mapping;

public static class WineMapping
{
    public static Wine toEntity(this CreateWineDto wine)
    {
        return new Wine()
        {
            Id = wine.Id,
            Name = wine.Name,
            Winery = wine.Winery,
            Location = wine.Location,
            Description = wine.Description,
            Price = wine.Price,
            Stock = wine.Stock,
            CategoryId = wine.CategoryId,
            Image = wine.Image
        };
    }

    public static Wine toEntity(this UpdateWineDto wine, int id)
    {
        return new Wine()
        {
            Id = id,
            Name = wine.Name,
            Winery = wine.Winery,
            Location = wine.Location,
            Description = wine.Description,
            Price = wine.Price,
            Stock = wine.Stock,
            CategoryId = wine.CategoryId,
            Image = wine.Image
        };
    }

    public static WineDetailsDto ToWineDetailsDto(this Wine wine)
    {
        return new(
            wine.Id,
            wine.Name,
            wine.Winery,
            wine.Location,
            wine.Description,
            wine.Category != null ? wine.Category.Label : "Unknown",
            wine.Price,
            wine.Stock,
            wine.Image
        );
    }

    public static UpdateWineDto ToUpdateWineDto(this Wine wine)
    {
        return new(
            wine.Name,
            wine.Winery,
            wine.Location,
            wine.Description,
            wine.Price,
            wine.Stock,
            wine.CategoryId,
            wine.Image
        );
    }

}
