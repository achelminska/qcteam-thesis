using QCteam.Modules.Catalog.Features.Contracts;
using QCteam.SharedKernel;

namespace QCteam.Modules.Catalog.Features;

public interface ISupplierService
{
    Task<Result<SupplierResponse>> CreateAsync(SupplierRequest request, CancellationToken ct);
    Task<Result<SupplierResponse>> GetAsync(Guid id, CancellationToken ct);
}