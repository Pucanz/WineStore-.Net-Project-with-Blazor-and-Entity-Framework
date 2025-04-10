namespace WineStoreFrontend.Models;

public class WineDetailsApi
{
    public Product Product { get; set; } = null!;
    public ProductCategory ProductCategory { get; set; } = null!;
    public ProductImage? ProductImage { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Winery { get; set; } = "";
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int ProductCategoryId { get; set; }
    
}

public class ProductCategory
{
    public int Id { get; set; }
    public string Label { get; set; } = "";
    public int Order { get; set; }
    public bool Is_Active { get; set; }
}

public class ProductImage
{
    public long ProductId { get; set; }
    public string Image { get; set; } = "";
}