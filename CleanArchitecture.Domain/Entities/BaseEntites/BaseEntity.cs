namespace CleanArchitecture.Domain.Entities.BaseEntities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateAt { get; set; }
}
