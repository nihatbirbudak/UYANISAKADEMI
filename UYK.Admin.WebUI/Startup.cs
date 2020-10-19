using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UYK.DAL;
using UYK.BLL.Services.Abstract;
using UYK.BLL.Services.UYKServices;
using UYK.Core.Data.UnitOfWork;
using UYK.Mapping.ConfigProfile;
using UYK.Model;
using UYK.WebUI.Admin.CustomHandler;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace UYK.Admin.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MapperConfing.RegisterMappers(); 
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Dependency Injection
            services.AddSingleton<IUnitofWork, UnitofWork>();
            services.AddSingleton<IAboutService, AboutService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IRoleService, RoleService>();




            //DbContext Settings
            var optionBuilder = new DbContextOptionsBuilder<UykDbContext>();
            optionBuilder.UseSqlServer(Configuration.GetConnectionString("UykDbContext"));
            optionBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionBuilder.EnableSensitiveDataLogging();

            services.AddSingleton<DbContext>(new UykDbContext(optionBuilder.Options));
            using (var context = new UykDbContext(optionBuilder.Options))
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }


            //Login Settings
            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie";
                     config.LoginPath = "/Login";
                     config.AccessDeniedPath = "/AccessDenied";
                 });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserPolicy", policyBuilder =>
                 {
                     policyBuilder.UserRequireCustomClaim(ClaimTypes.Email);
                 });
            });
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "Login",
                    defaults: new { controller = "Login", action = "UserLogin" });

                endpoints.MapControllerRoute(
                     name: "AccessDenied",
                     pattern: "AccessDenied",
                     defaults: new { controller = "Login", action = "AccessDenied" });

                endpoints.MapControllerRoute(
                    name: "AboutList",
                    pattern: "Page/About",
                    defaults: new { controller = "Page", Action = "AboutList" });

                endpoints.MapControllerRoute(
                    name: "AboutAdd",
                    pattern: "Page/About/Add",
                    defaults: new { controller = "Page", Action = "AboutAdd" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
