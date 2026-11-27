using QCteam.SharedKernel;

namespace QCteam.Modules.Identity.Domain;

public class User : BaseEntity
{
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public UserRole Role { get; set; } = UserRole.Controller;
    public string? ResetTokenHash { get; set; }
    public DateTime? ResetTokenExpiresAt { get; set; }
}
