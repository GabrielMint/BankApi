using AutoMapper;
using BankApi.Profiles;
using BankApi.ServiceExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BankApi
{
    public class Startup
    {

        public IConfigurationRoot Configuration;

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
            });

            services.AddScoped<IMapper>(x => new Mapper(mapperConfiguration));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankApi", Version = "v1" });
            });
            services.ConfigureLog();
            services.ConfigureInfrastructure(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankApi v1"));
            }
            
            app.UseRouting();
            app.UseEndpoints(e => e.MapControllers());
        }
    }
}
