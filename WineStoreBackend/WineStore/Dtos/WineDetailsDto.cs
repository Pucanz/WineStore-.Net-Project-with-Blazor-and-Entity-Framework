using System;

namespace WineStore.Dtos;

public record class WineDetailsDto
(
    int Id,
    string Name,
    string Winery,
    string Location,
    string Description,
    string Category,
    decimal Price,
    int Stock,
    string ImageUrl
);
