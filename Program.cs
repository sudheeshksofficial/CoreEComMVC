using CoreEComMVC.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace CoreEComMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EcommerceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                /*app.UseExceptionHandler("Home/Error");*/
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(name: "default",pattern: "{controller=Item}/{action=Index}/{id?}");

            /*app.MapGet("/", () => "Main user modified");*/

            app.Run();
        }
    }
}
