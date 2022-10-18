using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationContextImp : DbContext, IApplicationContext
{
    #region Constructor
    public ApplicationContextImp(DbContextOptions<ApplicationContextImp> options) : base(options) { }
    #endregion

    #region DbSet
    //public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    #endregion  

    #region Methods
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
    #endregion
}
