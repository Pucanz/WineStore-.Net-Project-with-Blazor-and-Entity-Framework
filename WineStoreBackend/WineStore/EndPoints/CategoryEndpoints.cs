using System;
using Microsoft.EntityFrameworkCore;
using WineStore.Dtos;
using WineStore.Mapping;
using WineStore.Migrations;

namespace WineStore.EndPoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("categories");
                     


        // Get all categories
        group.MapGet("/", async (WineStoreContext dbContext) =>
        {
            var categories = await dbContext.Categories.ToListAsync();
            return Results.Ok(categories);
        });


        // Get category by ID
        group.MapPost("/", async (WineStoreContext dbContext, CategoryDto categoryDto) =>
        {
            var category = categoryDto.toEntity();

            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();

            return Results.Created($"/categories/{category.Id}", category.toDto());
            
        });


        return group;
    }
}   
