using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using CleanArhcitecture.Application.Helper.Redis;
using MediatR;

namespace CleanArhcitecture.Application.Features.ProductFetures.Commands;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationContext _context;
        private readonly ICacheService _cache;
        public CreateProductCommandHandler(IApplicationContext context,ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                IsActive = request.IsActive,
                Barcode = request.Barcode,
                Description = request.Description
            };

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();
            _cache.RemoveData(CacheKeysRef.products);
            return product.Id;
        }

    }
}


