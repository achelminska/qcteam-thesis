namespace QCteam.Modules.Catalog.Features.Contracts;

public record SupplierRequest(
    string Name,
    string? ContactPerson,
    string? Email,
    string? Phone,
    string? Address);

public record SupplierResponse(
    Guid Id,
    string Name,
    string? ContactPerson,
    string? Email,
    string? Phone,
    string? Address,
    bool IsActive,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt);