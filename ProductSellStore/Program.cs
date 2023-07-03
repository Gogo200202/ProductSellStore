using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductSellStore.Data;
using ProductSellStore.Interface;
using ProductSellStore.Services;

namespace ProductSellStore
{
     public  class Program
    {
        public  static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ProductSellStoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
                {

                    options.SignIn.RequireConfirmedAccount = false;

                })
                .AddEntityFrameworkStores<ProductSellStoreDbContext>();

            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IProductSellStore, Services.ProductSellStore>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}