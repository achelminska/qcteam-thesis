using QCteam.SharedKernel;

namespace QCteam.Modules.Catalog.Domain;

public class Supplier : BaseEntity
{
    public string Name { get; set; } = "";
    public string? ContactPerson { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}