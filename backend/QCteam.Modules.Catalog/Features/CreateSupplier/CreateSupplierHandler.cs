using QCteam.Modules.Catalog.Features.Contracts;
using QCteam.SharedKernel;

namespace QCteam.Modules.Catalog.Features.CreateSupplier;

public class CreateSupplierHandler
{
    private readonly ISupplierService _service;

    public CreateSupplierHandler(ISupplierService service) => _service = service;

    public Task<Result<SupplierResponse>> HandleAsync(SupplierRequest request, CancellationToken ct)
        => _service.CreateAsync(request, ct);
}