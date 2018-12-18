using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CCA.Utilities
{
    public static class Seeder
    {
        private static string roleName = "Admin";

        public static void Seed(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var role = roleManager.RoleExistsAsync(roleName)
                .GetAwaiter()
                .GetResult();
            if (!role)
            {
                roleManager.CreateAsync(new IdentityRole { Name = roleName })
                    .GetAwaiter()
                    .GetResult();
            }
        }
    }
}

