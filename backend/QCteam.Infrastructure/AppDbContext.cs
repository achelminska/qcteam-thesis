using Microsoft.EntityFrameworkCore;
using QCteam.Modules.Catalog.Domain;
using QCteam.Modules.Identity.Domain;
using QCteam.SharedKernel;

namespace QCteam.Infrastructure;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<User> Users => Set<User>();

    public DbSet<Supplier> Suppliers => Set<Supplier>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("suppliers", "catalog");
            entity.Property(s => s.Name).IsRequired().HasMaxLength(200);
            entity.HasQueryFilter(s => s.DeletedAt == null);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users", "identity");
            entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(200);
            entity.Property(u => u.Role).HasConversion<string>().HasMaxLength(20);
            entity.Property(u => u.ResetTokenHash).HasMaxLength(200);
            entity.HasQueryFilter(u => u.DeletedAt == null);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.UpdatedAt = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}