using BankApi.Infrastructure.DatabaseConnection;
using BankApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.ServiceExtensions
{
    public static class InfrastructureServicesExtension
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseConnection>(cfg =>
            {
                var connectionString = "connectionString";

                return new DatabaseConnection(connectionString);
            });

            services.AddScoped<IAccountReader, AccountReader>();
        }
    }
}
