using WineStoreFrontend.Models;

namespace WineStoreFrontend.Clients;

public class WineClientApi(HttpClient httpClient)
{
    public async Task<WineDetailsApi[]> GetWinesAsync()
        => await httpClient.GetFromJsonAsync<WineDetailsApi[]>("GetProductsWithImages") ?? [];


    public async Task<WineDetailsApi> GetWineByIdAsync(int id)

        => await httpClient.GetFromJsonAsync<WineDetailsApi>($"GetProductById?ProductId={id}") ??
            throw new Exception($"Wine with id {id} not found");

}