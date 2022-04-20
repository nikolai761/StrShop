using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StrShop.Data;
using StrShop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using StrShop.Data.Repository;
using StrShop.Data.Models;

namespace StrShop
{
    public class Startup
    {

        private IConfigurationRoot _confstring;

        public Startup(IHostingEnvironment hostenv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostenv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBconnection>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllItems, ItemRepository>();
            services.AddTransient<IItemCategory, CategoryRepository>();
            services.AddTransient<IProducer, ProducerRepository>();
            services.AddTransient<IStorages, StoragesRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "item/{action}/{category?}", defaults: new { Controller = "Items", action = "ItemList"});
            });
                
            using (var scope = app.ApplicationServices.CreateScope())
            {
                DBconnection content = scope.ServiceProvider.GetRequiredService<DBconnection>();
                DbObject.initial(content);
            }
           
            
        }
    }
}
