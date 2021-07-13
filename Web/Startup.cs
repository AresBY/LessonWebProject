using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LessonWebProject.Data;
using LessonWebProject.BusinessLogic.Services;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.Data.Implementations.Repository;
using LessonWebProject.Data.Identity;
using LessonWebProject.Data.Identity.Interfaces.Repository;
using LessonWebProject.Data.Identity.Implementations.Repository;

namespace LessonWebProject.Web
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
            services.AddDbContext<EFContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
       
            services.AddDbContext<UserDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
             .AddEntityFrameworkStores<UserDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();



           

            services.AddAuthentication()
           .AddGoogle(options =>
           {
               IConfigurationSection googleAuthNSection =
                   Configuration.GetSection("Authentication:Google");

               options.ClientId = "1009810217144-jn8igdlu6upjkrckam0cbuuvi4rruuhk.apps.googleusercontent.com";
               options.ClientSecret = "2hgXFDOtHcudoY-yIkoGdO7i";
           });



           

            services.AddTransient<IUserTaskRepository, UserTaskRepository>();
            services.AddTransient<IAdsRepository, AdsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ServicesManager>();
            services.AddTransient<UserTaskService>();
            services.AddTransient<HomeService>();
            services.AddTransient<AdsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
