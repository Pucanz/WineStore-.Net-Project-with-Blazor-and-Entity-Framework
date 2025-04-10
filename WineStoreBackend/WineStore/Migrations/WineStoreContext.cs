
using Microsoft.EntityFrameworkCore;
using WineStore.Entities;

namespace WineStore.Migrations;

public class WineStoreContext(DbContextOptions<WineStoreContext> options) : DbContext(options)
{

    public DbSet<Wine> Wines => Set<Wine>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
         new Category { Id = 1, Label = "Rose" },
         new Category { Id = 2, Label = "Red" },
         new Category { Id = 3, Label = "White" }
        );
    }

}