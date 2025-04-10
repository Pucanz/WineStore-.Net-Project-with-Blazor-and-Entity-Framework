using System.ComponentModel.DataAnnotations;

namespace WineStoreFrontend.Models;

public class WineSummaryApi
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public required string Winery { get; set; }
    public required string Location { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required int Stock { get; set; }

    public required string Image { get; set; }
    
    public required string Category { get; set; }
}
