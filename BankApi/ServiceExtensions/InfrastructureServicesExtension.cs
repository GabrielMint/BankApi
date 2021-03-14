using BankApi.Infrastructure.DatabaseConnection;
using BankApi.Infrastructure.Repositories;
using BankApi.Infrastructure.Repositories.AccountWriter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

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
            services.AddScoped<IAccountWriter>(c =>
            {
                var databaseConnection = c.GetService<IDatabaseConnection>();

                var logger = c.GetService<ILogger>();

                var accountWriter = new AccountWriter(databaseConnection);

                return new AccountWriterWithErrorHandling(logger, accountWriter);
            });
        }
    }
}
