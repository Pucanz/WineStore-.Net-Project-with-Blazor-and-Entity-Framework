using WineStoreFrontend.Models;

namespace WineStoreFrontend.Clients;

public class CategoryClientApi(HttpClient httpClient)
{

    public async Task<Category[]> GetCategoriesAsync()
        => await httpClient.GetFromJsonAsync<Category[]>("GetCategories") ?? [];
}
