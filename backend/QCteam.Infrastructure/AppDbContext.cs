using Microsoft.EntityFrameworkCore;
using QCteam.Modules.Catalog.Domain;

namespace QCteam.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Supplier> Suppliers => Set<Supplier>();
}