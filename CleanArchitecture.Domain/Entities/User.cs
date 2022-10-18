using CleanArchitecture.Domain.Entities.BaseEntities;
namespace CleanArchitecture.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string MyProperty { get; set; }

}
