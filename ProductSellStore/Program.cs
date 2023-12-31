using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSellStore.Data;
using ProductSellStore.Data.Models;
using ProductSellStore.Infrastructure.ModelBunders;
using ProductSellStore.Interface;
using ProductSellStore.Services;
using ProductSellStore.Web.SeedRoles;

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

            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(
                    options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ProductSellStoreDbContext>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<Services.UserServices>();
            builder.Services.AddScoped<IUserServices,Services.UserServices>();
            builder.Services.AddScoped<IProductSellStoreServices, Services.ProductSellStoreServices>();
            builder.Services.AddScoped<IOrderServes, Services.OrderServes>();
            builder.Services.AddScoped<ICategoryServes, Services.CategoryServes>();
            builder.Services.AddScoped<ICommentServes, Services.CommentServes>();
           

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());

                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                
            }
            else
            {
               
                app.UseStatusCodePagesWithRedirects("/Home/Error?Code={0}");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdministrator("Admin@gmail.com");
            app.MakeWorkerRole();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}