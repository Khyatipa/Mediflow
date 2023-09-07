using Mediflow.DBModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;


namespace Mediflow
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages(); this line will keep by default Index.cshtml and that page will open  
            services.AddMvc().AddRazorPagesOptions(options=>
            {
                options.Conventions.AddPageRoute("/Home/Index","");  // Default Index Changed to LoginChemist see change in Debug

            });

            services.AddAntiforgery(o => {
                o.HeaderName = "XSRF-TOKEN";
                o.SuppressXFrameOptionsHeader = false;
            });

            services.AddDistributedMemoryCache();
            
            // services.AddDbContext<TestCoreContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            
            services.AddSession(o=> { o.IdleTimeout = TimeSpan.FromSeconds(1800); }); // logout auto matic after 1800 seconds
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// It will affect entering multiple data from one table to another
           // services.AddScoped<>;
            services.AddDbContext<MediflowContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
           

          

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
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

