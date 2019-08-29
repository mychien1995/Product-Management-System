using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Framework.Initializations;
using ProductMS.Models;

namespace ProductMS.DataAccess.SqlServer
{
    public class DataSeedingInitialization : IServiceInitializationModule
    {
        public void Initialize(IServiceCollection services)
        {
            var sysAdminRole = RoleNames.SYS_ADMIN;
            var sysAdminUsername = SystemConstants.ADMIN_USER_NAME;
            var sysAdminPassword = SystemConstants.ADMIN_USER_PASSWORD;
            var serviceProvider = services.BuildServiceProvider();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();
            if (!roleManager.RoleExistsAsync(sysAdminRole).Result)
            {
                ApplicationRole role = new ApplicationRole();
                role.Name = sysAdminRole;
                var createRole = roleManager.CreateAsync(role).Result;
            }
            if (userManager.FindByNameAsync(sysAdminUsername).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = sysAdminUsername;
                user.Email = "admin@localhost.com";
                user.Fullname = "SysAdmin";

                IdentityResult result = userManager.CreateAsync(user, sysAdminPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, sysAdminRole).Wait();
                }
            }
        }
    }
}
