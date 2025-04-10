using WineStoreFrontend.Models;

namespace WineStoreFrontend.Clients;

public class WineStoreClient(HttpClient httpClient)
{
    // Get all wines
    public async Task<WineStoreSummary[]> GetWinesAsync()
        => await httpClient.GetFromJsonAsync<WineStoreSummary[]>("wines") ?? [];

    // Get wine by id
    public async Task<WineStoreSummary> GetWineByIdAsync(int id)

        => await httpClient.GetFromJsonAsync<WineStoreSummary>($"wines/{id}") ??
            throw new Exception($"Wine with id {id} not found");

    // Create wine
    public async Task AddWineAsync(WineStoreDto wine)
        => await httpClient.PostAsJsonAsync("wines", wine);

    
    public async Task UpdateWineAsync(WineStoreDto updateWine)
    
        => await httpClient.PutAsJsonAsync($"wines/{updateWine.Id}", updateWine);



    // Delete wine from the database1
    public async Task DeleteWineAsync(int id)
    => await httpClient.DeleteAsync($"wines/{id}");
}


