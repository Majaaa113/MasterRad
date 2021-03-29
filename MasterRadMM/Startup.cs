using MasterRadMM.EntityFramework;
using MasterRadMM.Filters;
using MasterRadMM.Interfaces;
using MasterRadMM.Services;
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

namespace MasterRadMM
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
            var connectionString = Configuration.GetConnectionString("MasterRad");

            services.AddDbContext<MasterRadDbContext>(options =>
            {
                options.UseSqlServer(connectionString, m =>
                {
                    m.MigrationsHistoryTable("DBModel-MigrationAudit");
                    m.MigrationsAssembly("MasterRadMM");
                });
            });

            services.AddSession();
            services.AddHttpContextAccessor();

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICourierService, CourierService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<AllowOnlyEmployee>();

            services.AddControllersWithViews();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MasterRadDbContext>();

                if (context.Database.IsRelational())
                {
                    context.Database.Migrate();
                    context.Database.EnsureCreated();
                    new SeedData(context).Seed();
                }
            }            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}