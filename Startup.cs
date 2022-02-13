using EDPFinal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDPFinal
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
            services.AddDbContext<SLDbContext>();
            services.AddRazorPages();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddTransient<Services.AdminService>();
            services.AddDbContext<AdminDBContext>();
            services.AddDbContext<CourseDbContext>();
            services.AddDbContext<UserDbContext>(o =>
            {
                o.UseSqlServer("data source=.; " +
                    "initial catalog= SkillsLahDB; " +
                    "integrated security=true");
            });
            services.AddDbContext<BookingDBContext>();
            services.AddDbContext<GuidesDbContext>();
            services.AddTransient<Services.UserService>();
            services.AddTransient<Services.GuideService>();
            services.AddTransient<Services.CourseService>();
            services.AddTransient<Services.BookingService>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
