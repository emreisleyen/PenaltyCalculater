using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PenaltyCalculator.Infrastructure;
using PenaltyCalculator.Infrastructure.Service;
using PenaltyCalculator.Infrastructure.Service.Abstract;
using PenaltyCalculator.Infrastructure.Repository;
using PenaltyCalculator.Infrastructure.Repository.Abstract;
using PenaltyCalculator.Core.Entities;


namespace PenaltyCalculator.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
               services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddScoped<IRepository<Currency>, CurrencyRepository>();
            services.AddScoped<IRepository<Holiday>, HolidayRepository>();
            services.AddScoped<IPenaltyCalculatorService, PenaltyCalculatorService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddAutoMapper(typeof(Startup), typeof(PenaltyCalculatorDbContext));
            services.AddDbContext<DbContext,PenaltyCalculatorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
