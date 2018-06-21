using FootballTeams.Data;
using FootballTeams.Infrastructure.Filters;
using FootballTeams.Repositories;
using FootballTeams.Repositories.Contracts;
using FootballTeams.Services;
using FootballTeams.Services.Contracts;
using FootballTeams.UnitOfWork.Contracts;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballTeams
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
            // data services
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IDtoService, DtoService>();
            services.AddScoped<IXmlService, XmlService>();
            services.AddScoped<ITeamService, TeamService>();

            // db services
            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddDbContext<FootballTeamsContext>(cfg =>
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // filter services
            services.AddScoped<SaveChangesFilter>();

            // Add framework services
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
