using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArhcitecture.Application.Features.Services.ProductService.Interfaces;
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
        private readonly IProductService _product;
        public GetAllProductQueryHandler(IApplicationContext context, ICacheService cache, IProductService product)
        {
            _context = context;
            _cache = cache;
            _product = product;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _product.GetProductsFromCacheIsNoThenSetAsync(cancellationToken);
            return products;
        }
    }
}
