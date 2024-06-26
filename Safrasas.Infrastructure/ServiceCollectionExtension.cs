using Safrasas.Application.Interfaces;
using Safrasas.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Safrasas.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
