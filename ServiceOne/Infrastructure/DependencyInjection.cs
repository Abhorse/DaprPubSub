using Infrastructure.Contract;
using Infrastructure.Persistence.Dapr;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDaprInfrastructure, DaprInfrastructure>();
            return services;
        }
    }
}