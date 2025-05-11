using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Bson;
using BookShop.Constants;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa odpowiedzialna za wstawienie początkowych danych do bazy danych, takich jak np. role użytkowników
    /// </summary>
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();

            //roles to db

            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //deafault admin from keyboard

            var admin = new IdentityUser
            {
                UserName = "adam.krystek03@gmail.com",
                Email = "adam.krystek03@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if (userInDb is null) 
            {
                await userMgr.CreateAsync(admin, "Admin123!");
                await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }

    }
}
