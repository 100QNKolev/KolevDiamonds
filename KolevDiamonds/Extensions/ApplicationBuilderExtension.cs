using Microsoft.AspNetCore.Identity;
using static KolevDiamonds.Infrastructure.Data.Models.AdminUser;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtension
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        { 
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRoleName) == false)
            {
                var role = new IdentityRole(AdminRoleName);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync(AdminEmail);

                if (admin != null) 
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }
        }
    }
}
