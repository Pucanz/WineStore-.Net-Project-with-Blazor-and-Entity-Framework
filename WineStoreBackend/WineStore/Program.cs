using WineStore.EndPoints;
using WineStore.Migrations;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("WineStore");
builder.Services.AddSqlite<WineStoreContext>(connString);

var app = builder.Build();

app.MapWineEndpoints();
app.MapCategoryEndpoints();

await app.MigrateDbAsync();

app.Run();