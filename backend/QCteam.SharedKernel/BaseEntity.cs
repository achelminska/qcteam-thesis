namespace QCteam.SharedKernel;

// to co wszystkie tabele mają wspólnego
public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public void SoftDelete(DateTime nowUtc) => DeletedAt = nowUtc;
    public void Restore() => DeletedAt = null;
}