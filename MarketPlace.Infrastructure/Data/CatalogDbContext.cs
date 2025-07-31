using MarketPlace.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions options): base(options) { }

    public DbSet<ProductEntity> Products { get; set; }
}
