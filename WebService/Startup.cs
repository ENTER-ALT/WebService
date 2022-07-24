
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebService.Service;
using WebService.Domain.Updaters;
using WebService.Domain.Abstractions;
using WebService.Domain;

namespace WebService
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
            //Подключение информации из appsettings.json 
            Configuration.Bind("WebService", new Config());
            Configuration.Bind("ErrorMessages", new ErrorMessages());

            //Подключение сервисов
            services.AddTransient<IMessageItemUpdater, MessageItemUpdater>();
            services.AddTransient<IUserInfoUpdater, UserInfoUpdater>();
            services.AddTransient<DataManager>();

            //Подключение контекста БД
            services.AddDbContext<AppDbContext>(x=> x.UseSqlServer(Config.ConnectionString));

            //Подключение сервисов MVC
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("messenger", "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
