using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCBasics.DataAccess;
using MVCBasics.Models;
using MVCBasics.Models.Auth;
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
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();

            services.AddIdentity<AppUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();
            
            services.AddControllersWithViews();
            services.AddRazorPages();
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=About}/{id?}");
                endpoints.MapControllerRoute(
                    "About",
                    "{action=About}",
                    defaults: new {controller = "Home", action = "About"}
                );
                endpoints.MapControllerRoute(
                    "Contact",
                    "{action=Contact}",
                    defaults: new {controller = "Home", action = "Contact"}
                );
                endpoints.MapControllerRoute(
                    "Projects",
                    "{action=Projects}",
                    defaults: new {controller = "Home", action = "Projects"}
                );
            });
            
        }
    }
}