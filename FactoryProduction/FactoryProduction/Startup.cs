using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FactoryProduction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FactoryProduction.Models;

namespace FactoryProduction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddMvc();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddMvc();
        }



        public void Configure(IApplicationBuilder app, ApplicationContext context)
        {
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default1",
                   template: "Aircraft",
                   defaults: new { controller = "Aircraft", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }
    }
}
/*using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FactoryProduction.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext()
        { }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Factories> Factories { get; set; }
        public virtual DbSet<PlanOfImplement> PlanOfImplement { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<ReleacePlan> ReleacePlan { get; set; }

        
    }
}*/