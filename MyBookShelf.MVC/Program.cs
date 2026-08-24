using MyBookShelf.Shared.DataAccess.Factories;
using MyBookShelf.Shared.DataAccess.Repositories;

namespace MyBookShelf.MVC
{
    public sealed class Program
    {
        #region Main

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

        #endregion

        #region Builder

        private static WebApplicationBuilder CreateBuilder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookContentsReader, BookContentsReader>();

            return builder;
        }

        #endregion
    }
}
