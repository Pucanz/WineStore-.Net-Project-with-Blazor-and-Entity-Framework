using WineStoreFrontend.Clients;
using WineStoreFrontend.Components;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var wineStoreApiUrl = builder.Configuration["WineStoreApiUrl"] ??
    throw new Exception("WineStoreApi is not set");

var wineStoreUrl = builder.Configuration["WineStoreUrl"] ??
    throw new Exception("WineStore is not set");

// Wine Store API Client
builder.Services.AddHttpClient<WineClientApi>(
    Client => Client.BaseAddress = new Uri(wineStoreApiUrl));

builder.Services.AddHttpClient<CategoryClientApi>(
    Client => Client.BaseAddress = new Uri(wineStoreApiUrl));

// Wine Store Client

builder.Services.AddHttpClient<WineStoreClient>(
    Client => Client.BaseAddress = new Uri(wineStoreUrl));

builder.Services.AddHttpClient<CategoryStoreClient>(
    Client => Client.BaseAddress = new Uri(wineStoreUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
Console.WriteLine("Wine Store starts");
