using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OA.Application.Interfaces;
using OA.Application.Interfaces.Repositories;
using OA.Application.Services;
using OA.Persistence.Context;
using OA.Persistence.Repositories;

namespace OA.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null || configuration["UseInMemoryDb"]! == "True")
                services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));
            else
                services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}