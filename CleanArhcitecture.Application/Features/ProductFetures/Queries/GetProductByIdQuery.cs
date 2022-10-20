using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArhcitecture.Application.Helper.Redis;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArhcitecture.Application.Features.ProductFetures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandle : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicationContext _context;
            private readonly ICacheService _cache;
            public GetProductByIdQueryHandle(IApplicationContext context, ICacheService cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                Product product;
                var products = _cache.GetData<IEnumerable<Product>>("products");
                if (products == null)
                {
                    products = await _context.Products.ToListAsync();
                    DateTimeOffset expirationTime = DateTimeOffset.Now.AddMinutes(15.0);
                    _cache.SetData("products", products, expirationTime);

                    product = products.FirstOrDefault(x => x.Id == request.Id);

                    return product;
                }
                product = products.FirstOrDefault(x => x.Id == request.Id);

                if (product is null) return null;

                return product;

            }
        }
    }
}
