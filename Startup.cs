using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FishStore.Models;

namespace FishStore
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
            services.AddDbContext<FishDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FishDbContext")
            ));
            services.AddScoped<IFishStoreRepository,EFFishStoreRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();

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
            app.UseSession();
            app.UseAuthorization();
            // old URL: http://localhost:44333/?Page=2
            // new URL: https://localhost:44333/Fishs/2
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("default", "{controller}/{action}",
                //new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("genpage","{genre}/{Page:int}",
                new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("page", "{Page:int}",
                new { Controller = "Home", action = "Index", Page = 1 });
                endpoints.MapControllerRoute("genre", "{genre}",
                new { Controller = "Home", action = "Index", Page = 1 });
                endpoints.MapControllerRoute("pagination","Fishs/{Page}",
                new { Controller = "Home", action = "Index", Page = 1 });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();

            });

        }
    }
}
