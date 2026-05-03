using Microsoft.AspNetCore.Identity;

namespace C__Advanced_Final_Project.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>();

            string username = "adminUsername";
            string password = "Admin1!";
            string roleName = "Admin";

            if (await roleManager.FindByNameAsync(roleName) == null)
                await roleManager.CreateAsync(new IdentityRole(roleName));

            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username, FName = "Admin", LName = "User" };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}