using Microsoft.AspNetCore.Mvc;
using QCteam.Modules.Catalog.Features.Contracts;
using QCteam.SharedKernel.Http;

namespace QCteam.Modules.Catalog.Features.GetSupplier;

[Route("api/suppliers")]
public class GetSupplierEndpoint : ApiControllerBase
{
    private readonly GetSupplierHandler _handler;

    public GetSupplierEndpoint(GetSupplierHandler handler) => _handler = handler;

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SupplierResponse>> Get(Guid id, CancellationToken ct)
        => ToActionResult(await _handler.HandleAsync(id, ct));
}
