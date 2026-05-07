using C__Advanced_Final_Project.Data;
using C__Advanced_Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace C__Advanced_Final_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EventContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EventContext")));
        

            builder.Services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<EventContext>()
            .AddDefaultTokenProviders();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                // Admin
                if (await roleManager.FindByNameAsync("Admin") == null)
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                if (await userManager.FindByNameAsync("adminUsername") == null)
                {
                    User user = new User { UserName = "adminUsername", FName = "Admin", LName = "User" };
                    var result = await userManager.CreateAsync(user, "Admin1!");
                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(user, "Admin");
                }

                // Driver
                if (await roleManager.FindByNameAsync("Driver") == null)
                    await roleManager.CreateAsync(new IdentityRole("Driver"));
                if (await userManager.FindByNameAsync("driverUsername") == null)
                {
                    User user = new User { UserName = "driverUsername", FName = "Driver", LName = "User" };
                    var result = await userManager.CreateAsync(user, "Driver1!");
                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(user, "Driver");
                }
            }

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}