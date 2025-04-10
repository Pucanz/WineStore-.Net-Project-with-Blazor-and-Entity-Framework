using System;

namespace WineStoreFrontend.Models;

public class WineStoreDto
{
    public int Id { get; set; }
    public string ? Name { get; set; }
    public string ? Winery { get; set; }
    public string ? Location { get; set; }
    public string ? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public string ? Image { get; set; }
}
