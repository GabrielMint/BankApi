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
                    .WriteTo.Logger(lc => lc.WriteTo.Console())
                    .WriteTo.Logger(lc => lc
                    .MinimumLevel.Error()
                    .WriteTo.Discord(ulong.Parse("755940966648643711"),
                    "yCeAk7OKrxTGbeXuYq-rwFy62cP46l-24n0a7FWKHLNLvyf5v8a-XWznunueW4PNckpA"))
                    .CreateLogger();

                return Log.Logger; 
            });
        }
    }
}
