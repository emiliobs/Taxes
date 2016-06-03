using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxes.Models;

namespace Taxes.Classes
{
    public class Utilities : IDisposable
    {

        private static ApplicationDbContext userContext = new ApplicationDbContext();

        public static void CheckRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            //Check to see if role Exists, if not create it.
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            //Busco si existe el usuario:
            var userASP = userManager.FindByName("barrera_emilio@hotmail.com");
            if (userASP == null)
            {
                CreateUserASP("barrera_emilio@hotmail.com", "Admin");

                return;
            }

            //Si el usuario existe, garantizo el role;
            userManager.AddToRole(userASP.Id, "Admin");
        }

        public static void CreateUserASP(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, email);
            userManager.AddToRole(userASP.Id, roleName);
        }



        public void Dispose()
        {
            userContext.Dispose();
        }
    }
}
