namespace AssetManagement.Migrations.AccountScripts
{
    using AssetManagement.Data;
    using AssetManagement.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AssetManagement.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\AccountScripts";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("ResourceChecker"))
                roleManager.Create(new IdentityRole("Resource Checker"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.FindByEmail("superadmin@cse5320.edu") == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Eknaut",
                    LastName = "Prasad",
                    Email = "superadmin@cse5320.edu",
                    UserName = "superadmin@cse5320.edu",
                    IsAdmin = true,
                    IsActive = true
                };
                var result = userManager.Create(user, "Passme@123");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }

            if (userManager.FindByEmail("sanketkale92@yahoo.com") == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Sanket",
                    LastName = "Kale",
                    Email = "sanketkale92@yahoo.com",
                    UserName = "sanketkale92@yahoo.com",
                    IsAdmin = false,
                    IsActive = true
                };
                var result = userManager.Create(user, "Passme@123");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Resource Checker");
            }
        }
    }
}
