using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCBasics.DataAccess;
using MVCBasics.Models;
using MVCBasics.Models.Interfaces;
using MVCBasics.Models.Repository;

namespace MVCBasics
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString , ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();

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

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Portfolio}/{action=About}/{id?}");
                endpoints.MapControllerRoute(
                    "About",
                    "{action=About}",
                    defaults: new {controller = "Portfolio", action = "About"}
                );
                endpoints.MapControllerRoute(
                    "Contact",
                    "{action=Contact}",
                    defaults: new {controller = "Portfolio", action = "Contact"}
                );
                endpoints.MapControllerRoute(
                    "Projects",
                    "{action=Projects}",
                    defaults: new {controller = "Portfolio", action = "Projects"}
                );

                endpoints.MapControllerRoute(
                    "People",
                    "{controller=People}/{action=Index}/{id?}"
                );
            });
            // populate db
            Seed.PopulateDb(app);
        }
    }
}