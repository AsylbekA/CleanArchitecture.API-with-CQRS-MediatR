using CleanArhcitecture.Application.Features.Services.ProductService;
using CleanArhcitecture.Application.Features.Services.ProductService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArhcitecture.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductServiceImp>();
            return services;
        }
    }
}
