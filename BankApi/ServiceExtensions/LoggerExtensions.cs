using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Filters;
using Serilog.Sinks.Discord;

namespace BankApi.ServiceExtensions
{
    public static class LoggerExtensions
    {
        public static void ConfigureLog(this IServiceCollection services)
        {
            services.AddSingleton<ILogger>(resolver =>
            {
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .Filter.ByExcluding(Matching.FromSource("Microsoft"))
                    .Filter.ByExcluding(Matching.FromSource("System"))
                    .Filter.ByExcluding(Matching.FromSource("Serilog"))
                    .WriteTo.Logger(lc => lc
                    .MinimumLevel.Error()
                    .WriteTo.Discord(ulong.Parse("820723101604118569"),
                    "y_tBop-ZSsSKGFd6l_CUE0_wzU6tYEMBzYq1k9z6-uB_JpdR0ZyjGD2hB0v3jXQULctI"))
                    //https://discord.com/api/webhooks/820723101604118569/y_tBop-ZSsSKGFd6l_CUE0_wzU6tYEMBzYq1k9z6-uB_JpdR0ZyjGD2hB0v3jXQULctI
                    .CreateLogger();

                return Log.Logger; 
            });
        }
    }
}
