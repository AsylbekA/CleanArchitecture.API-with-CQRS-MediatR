using CleanArchitecture.Domain.Entities.BaseEntities;

namespace CleanArchitecture.Domain.Entities;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }

}
