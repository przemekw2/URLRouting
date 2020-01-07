using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace webapp
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes => {

                routes.MapRoute(name: "MyRoute",
                    template: "{controller=Home}/{action=Index}/{id=DefaultId}");

                //routes.MapRoute(name: "ShopSchema",
                //template: "Shop/{action}",
                //defaults: new { controller = "Home", action = "Index" });

                //routes.MapRoute("", "X{controller}/{action}");

                //routes.MapRoute(
                //name: "default",
                //template: "{controller=Home}/{action=Index}");

                //routes.MapRoute(name: "",
                //template: "Public/{controller=Home}/{action=Index}");

            });
            //app.UseMvc();
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            //app.UseMvc(option => option.EnableEndpointRouting = false);

            /*
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
            */
        }
    }
}
