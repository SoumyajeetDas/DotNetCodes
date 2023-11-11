using EnitityFrameworkWithASP.NETCore.Data;
using EnitityFrameworkWithASP.NETCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnitityFrameworkWithASP.NETCore
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
            
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookDbConnection")));

            services.AddScoped<IBookRepository, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithRedirects("/Error/{0}");

                app.UseExceptionHandler("/Error/Exception");

            }
            else
            {

                app.UseStatusCodePagesWithRedirects("/Error/{0}");

                app.UseExceptionHandler("/Error/Exception");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Book}/{action=AddBook}/{id?}");

                //endpoints.MapControllerRoute(name: "GetAllBooks", pattern: "{action=GetAllBooks}/{controller?}");

                //endpoints.MapControllerRoute(name: "GetBook", pattern: "{controller}/{action=GetBook}/{id=3}");
            });
        }
    }
}
