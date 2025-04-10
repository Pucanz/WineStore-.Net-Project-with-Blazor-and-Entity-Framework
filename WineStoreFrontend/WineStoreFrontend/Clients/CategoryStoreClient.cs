using WineStoreFrontend.Models;

namespace WineStoreFrontend.Clients;

public class CategoryStoreClient(HttpClient httpClient)
{

    public async Task<Category[]> GetCategoriesAsync()
        => await httpClient.GetFromJsonAsync<Category[]>("/categories") ?? [];
}
