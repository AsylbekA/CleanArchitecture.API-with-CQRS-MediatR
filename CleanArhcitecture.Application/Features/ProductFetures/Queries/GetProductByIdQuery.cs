using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhcitecture.Application.Features.ProductFetures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandle : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicationContext _context;
            public GetProductByIdQueryHandle(IApplicationContext context) => _context = context;

            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(p => p.Id == request.Id).AsNoTracking().FirstOrDefaultAsync(cancellationToken: cancellationToken);
                if (product is null) return null;

                return product;

            }
        }
    }
}
