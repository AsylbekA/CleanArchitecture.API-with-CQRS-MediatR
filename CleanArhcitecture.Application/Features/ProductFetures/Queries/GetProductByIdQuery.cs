using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArhcitecture.Application.Features.Services.ProductService.Interfaces;
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
            private readonly IProductService _product;
            public GetProductByIdQueryHandle(IApplicationContext context, ICacheService cache, IProductService product)
            {
                _context = context;
                _cache = cache;
                _product = product;
            }

            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                Product product;
                var products = await _product.GetProductsFromCacheIsNoThenSetAsync(cancellationToken);
                product = products.FirstOrDefault(x => x.Id == request.Id);
                if (product is null) return null;
                return product;

            }
        }
    }
}
