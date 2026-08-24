using MyBookShelf.Shared.DataAccess.Factories;
using MyBookShelf.Shared.DataAccess.Repositories;
using MyBookShelf.Shared.Models;

namespace MyBookShelf.MVC
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = CreateBuilder(args).Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Books}/{action=Index}/{id?}");

            app.Run();
        }

        private static WebApplicationBuilder CreateBuilder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();

            return builder;
        }
    }
}
