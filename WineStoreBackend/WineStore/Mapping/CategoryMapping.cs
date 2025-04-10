using WineStore.Dtos;
using WineStore.Entities;

namespace WineStore.Mapping;

public static class CategoryMapping
{
    public static CategoryDto toDto(this Category category)
    {
        return new CategoryDto(category.Id, category.Label);
    }

    public static Category toEntity(this CategoryDto dto)
    {
        return new Category
        {
            Id = dto.Id,
            Label = dto.Label
        };
    }
}
