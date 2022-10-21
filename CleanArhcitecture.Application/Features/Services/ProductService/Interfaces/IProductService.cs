using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhcitecture.Application.Features.Services.ProductService.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsFromCacheIsNoThenSetAsync(CancellationToken cancellationToken);

    }
}
