using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Domain.Contracts;

public interface IApplicationContext
{
   // DbSet<User> Users { get; set; }
    DbSet<Product> Products { get; set; }

    Task<int> SaveChangesAsync();
}
