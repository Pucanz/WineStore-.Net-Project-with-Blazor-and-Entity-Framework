using Microsoft.EntityFrameworkCore;

namespace WineStore.Migrations;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WineStoreContext>();
        await dbContext.Database.MigrateAsync();
    }

}
