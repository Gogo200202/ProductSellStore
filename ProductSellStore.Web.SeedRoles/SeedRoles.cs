
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProductSellStore.Data.Models;


namespace ProductSellStore.Web.SeedRoles
{
    

    public static class SeedRoles
    {
        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            const string AdminRoleName = "Admin";
            Task.Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdminRoleName))
                    {
                        return;
                    }

                    IdentityRole role = new IdentityRole(AdminRoleName);

                    await roleManager.CreateAsync(role);

                    ApplicationUser adminUser =
                        await userManager.FindByEmailAsync(email);

                    await userManager.AddToRoleAsync(adminUser, AdminRoleName);
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }

        public static IApplicationBuilder MakeWorkerRole(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

           
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            const string WorkerRoleName = "Worker";
            Task.Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(WorkerRoleName))
                    {
                        return;
                    }

                    IdentityRole role = new IdentityRole(WorkerRoleName);

                    await roleManager.CreateAsync(role);

                   
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }

        
    }
}