using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using OA.Application.Interfaces;
using OA.Application.Interfaces.Repositories;
using OA.Application.Services;

namespace OA.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            
            // SOA
            services.AddTransient<IProductService, ProductService>();
        }
    }
}