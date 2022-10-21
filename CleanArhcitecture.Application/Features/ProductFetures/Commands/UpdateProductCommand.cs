using CleanArchitecture.Domain.Contracts;
using CleanArhcitecture.Application.Helper.Redis;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArhcitecture.Application.Features.ProductFetures.Commands;

public class UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationContext _context;
        private readonly ICacheService _cache;

        public UpdateProductCommandHandler(IApplicationContext context, ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }
    public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(p => p.Id == request.Id).AsNoTracking().FirstOrDefault();

            if (product is null) return default;

            product.Name = request.Name;
            product.Price = request.Price;
            product.IsActive = request.IsActive;
            product.Barcode = request.Barcode;
            product.Description = request.Description;

            await _context.SaveChangesAsync();
            _cache.RemoveData(CacheKeysRef.products);
            return product.Id;
        }
    }
}