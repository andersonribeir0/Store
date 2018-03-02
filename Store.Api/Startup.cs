using System.IO;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Infra.Repositories;
using Store.Infra.StoreContext.DataContexts;
using Store.Infra.StoreContext.Repositories;
using Store.Shared;

namespace Store.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
            services.AddScoped<StoreDataContext>();

            services.AddTransient<CustomerHandler>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
           
        }
    }
}
