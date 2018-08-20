
using CORE.NG.API.Extensions;
using CORE.NG.DATA.Context;
using CORE.NG.DATA.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NG.CORE.BUSINESS;

namespace CORE.NG.API
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
           // services.AddDbContext<DataContext>();
            // services.AddDbContext<IDevDataContext, SqliteDataContext>(x => x.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));
            services.AddDbContext<IDataContext, DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SqliteConnection")));
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamBL, TeamBL>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.ConfigureExceptionHandler();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.ConfigureExceptionHandler();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
