﻿using CleanArchitecture.Domain.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArhcitecture.Application.Features.ProductFetures.Commands;

public class DeleteProductCommand : IRequest<int>
{
    public int Id { get; set; }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IApplicationContext _context;

        public DeleteProductCommandHandler(IApplicationContext context) => _context = context;
        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(p => p.Id == command.Id).AsNoTracking().FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (product is null) return default;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
