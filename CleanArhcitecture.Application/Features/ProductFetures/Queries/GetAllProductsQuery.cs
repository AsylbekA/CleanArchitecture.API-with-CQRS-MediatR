using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArhcitecture.Application.Helper.Redis;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArhcitecture.Application.Features.ProductFetures.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
    public IEnumerable<Product> Products { get; set; }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationContext _context;
        private readonly ICacheService _cache;
        public GetAllProductsQueryHandler(IApplicationContext context,ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
           // IEnumerable<Product> products = _cache.GetData<IEnumerable<Product>>("products");

           // if (products != null) return products;

            DateTimeOffset expirationTime = DateTimeOffset.Now.AddMinutes(15.0);
        var    products = await _context.Products.ToListAsync();
           // _cache.SetData("products", products, expirationTime);
        
            return products;
        }
    }
}
