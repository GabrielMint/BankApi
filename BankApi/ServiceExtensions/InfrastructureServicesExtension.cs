using BankApi.Infrastructure.DatabaseConnection;
using BankApi.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.ServiceExtensions
{
    public static class InfrastructureServicesExtension
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IDatabaseConnection>(cfg =>
            {
                var connectionString = configuration.GetValue<string>("DbConnectionString");

                return new PgSqlConnection(connectionString);
            });

            services.AddScoped<IAccountReader, AccountReader>();
        }
    }
}
