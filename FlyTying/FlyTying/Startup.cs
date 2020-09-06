using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyTying.Application;
using FlyTying.Application.Interfaces;
using FlyTying.Application.Repositories;
using FlyTying.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FlyTying
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FlyRecipeDatabaseSettings>(
                Configuration.GetSection(nameof(FlyRecipeDatabaseSettings)));

            services.AddSingleton<IFlyRecipeDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<FlyRecipeDatabaseSettings>>().Value);

            services.AddScoped(typeof(IAsyncRepository<>), typeof(MongoAsyncRepository<>));
            services.AddScoped<IRecipeRepository, RecipeRepository>();


            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
