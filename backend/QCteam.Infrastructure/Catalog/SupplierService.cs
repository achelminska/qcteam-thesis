using Microsoft.EntityFrameworkCore;
using QCteam.Modules.Catalog.Domain;
using QCteam.Modules.Catalog.Features;
using QCteam.Modules.Catalog.Features.Contracts;
using QCteam.SharedKernel;

namespace QCteam.Infrastructure.Catalog;

public class SupplierService : ISupplierService
{
    private readonly AppDbContext _db;

    public SupplierService(AppDbContext db) => _db = db;

    public async Task<Result<SupplierResponse>> CreateAsync(SupplierRequest request, CancellationToken ct)
    {
        var supplier = new Supplier
        {
            Name = request.Name,
            ContactPerson = request.ContactPerson,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address
        };

        _db.Suppliers.Add(supplier);
        await _db.SaveChangesAsync(ct);

        return ToResponse(supplier);
    }

    public async Task<Result<SupplierResponse>> GetAsync(Guid id, CancellationToken ct)
    {
        var supplier = await _db.Suppliers.FirstOrDefaultAsync(s => s.Id == id, ct);

        if (supplier is null)
            return Error.NotFound("supplier_not_found", "Nie ma takiego dostawcy.");

        return ToResponse(supplier);
    }

    private static SupplierResponse ToResponse(Supplier s) => new(
        s.Id, s.Name, s.ContactPerson, s.Email, s.Phone, s.Address,
        s.IsActive, s.CreatedAt, s.UpdatedAt, s.DeletedAt);
}