using Microsoft.EntityFrameworkCore;
using WineStore.Dtos;
using WineStore.Entities;
using WineStore.Mapping;
using WineStore.Migrations;

namespace WineStore.EndPoints;

public static class WineEndpoint
{
    const string GetWineEndpointName = "GetWine";


    public static RouteGroupBuilder MapWineEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("wines");



        // Get all wines
        group.MapGet("/", async (WineStoreContext dbContext) =>
        {
            return await dbContext.Wines
                .Include(wine => wine.Category)
                .Select(wine => wine.ToWineDetailsDto())
                .AsNoTracking()
                .ToListAsync();
        });

        // Get wine by ID /wines/1
        group.MapGet("/{id}", async (int id, WineStoreContext dbContext) =>
       {
           Wine? wine = await dbContext.Wines
               .Include(w => w.Category)
               .FirstOrDefaultAsync(w => w.Id == id);

           return wine is null
               ? Results.NotFound()
               : Results.Ok(wine.ToWineDetailsDto());
       })
       .WithName(GetWineEndpointName);


        // Post a new wine
        group.MapPost("/", async (CreateWineDto newWine, WineStoreContext dbContext) =>
        {
            Wine wine = newWine.toEntity();

            dbContext.Wines.Add(wine);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetWineEndpointName, new { id = wine.Id },
                wine.ToWineDetailsDto());
        });

        // Put /wines/1

        group.MapPut("/{id}", async (int id, UpdateWineDto updatedWine, WineStoreContext dbContext) =>
        {
            var existingWine = await dbContext.Wines.FindAsync(id);

            if (existingWine is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingWine)
                     .CurrentValues
                     .SetValues(updatedWine.toEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });


        // DELETE WINE /wine/1
        group.MapDelete("/{id}", async (int id, WineStoreContext dbContext) =>
        {
            await dbContext.Wines.Where(wine => wine.Id == id).ExecuteDeleteAsync();

            return Results.NoContent();
        });


        return group;
    }

}
