using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArhcitecture.Application.Helper.Redis;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArhcitecture.Application.Features.ProductFetures.Queries;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IApplicationContext _context;
        private readonly ICacheService _cache;
        public GetAllProductQueryHandler(IApplicationContext context, ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
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
