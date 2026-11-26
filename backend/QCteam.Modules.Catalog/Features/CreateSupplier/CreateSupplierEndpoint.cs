using Microsoft.AspNetCore.Mvc;
using QCteam.Modules.Catalog.Features.Contracts;
using QCteam.SharedKernel.Http;

namespace QCteam.Modules.Catalog.Features.CreateSupplier;

[Route("api/suppliers")]
public class CreateSupplierEndpoint : ApiControllerBase
{
    private readonly CreateSupplierHandler _handler;

    public CreateSupplierEndpoint(CreateSupplierHandler handler) => _handler = handler;

    [HttpPost]
    public async Task<ActionResult<SupplierResponse>> Create(SupplierRequest request, CancellationToken ct)
        => ToActionResult(await _handler.HandleAsync(request, ct));
}