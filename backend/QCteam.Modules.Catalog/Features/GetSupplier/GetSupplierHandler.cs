using QCteam.Modules.Catalog.Features.Contracts;
using QCteam.SharedKernel;

namespace QCteam.Modules.Catalog.Features.GetSupplier;

public class GetSupplierHandler
{
    private readonly ISupplierService _service;

    public GetSupplierHandler(ISupplierService service) => _service = service;

    public Task<Result<SupplierResponse>> HandleAsync(Guid id, CancellationToken ct)
        => _service.GetAsync(id, ct);
}