using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Application.Context;
using SimpleCrud.Application.Repositories;
using SimpleCrud.Persistence.Configurations;
using SimpleCrud.Persistence.Context;
using SimpleCrud.Persistence.Repositories;

namespace SimpleCrud.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services)
        {
            ProductConfiguration.Configure();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}