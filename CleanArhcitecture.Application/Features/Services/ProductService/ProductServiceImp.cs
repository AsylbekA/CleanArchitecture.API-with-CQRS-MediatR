using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArhcitecture.Application.Features.Services.ProductService.Interfaces;
using CleanArhcitecture.Application.Helper.Redis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhcitecture.Application.Features.Services.ProductService
{
    public class ProductServiceImp : IProductService
    {
        private readonly IApplicationContext _context;
        private readonly ICacheService _cache;

        public ProductServiceImp(IApplicationContext context, ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<IEnumerable<Product>> GetProductsFromCacheIsNoThenSetAsync(CancellationToken cancellationToken)
        {
            var products = _cache.GetData<IEnumerable<Product>>(CacheKeysRef.products);
            if (products != null) return products;
            products = await _context.Products.ToListAsync(cancellationToken);
            if (products is null) return null;

            DateTimeOffset expirationTime = DateTimeOffset.Now.AddMinutes(15.0);
            _cache.SetData(CacheKeysRef.products, products, expirationTime);
            return products;
        }
    }
}
