namespace WineStore.Entities;

public class Wine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Winery { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category ? Category { get; set; }
}
