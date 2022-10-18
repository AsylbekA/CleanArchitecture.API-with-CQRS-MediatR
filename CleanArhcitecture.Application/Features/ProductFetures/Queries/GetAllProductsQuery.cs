using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArhcitecture.Application.Features.ProductFetures.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
    public IEnumerable<Product> Products { get; set; }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationContext _context;
        public GetAllProductsQueryHandler(IApplicationContext context) => _context = context;

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}
