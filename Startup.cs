using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCBasics.Models;
using MVCBasics.Models.Interfaces;

namespace MVCBasics
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProjectsRepository , ProjectsRepository>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     "default",
                    "{controller=Portfolio}/{action=About}/{id?}");
                endpoints.MapControllerRoute(
                    "About",
                    "{action=About}",
                    defaults: new { controller = "Portfolio" , action = "About"}
                );
                endpoints.MapControllerRoute(
                    "Contact",
                    "{action=Contact}",
                    defaults: new { controller = "Portfolio" , action = "Contact"}
                );
                endpoints.MapControllerRoute(
                    "Projects",
                    "{action=Projects}",
                    defaults: new { controller = "Portfolio" , action = "Projects"}
                );
            });
        }
    }
}
