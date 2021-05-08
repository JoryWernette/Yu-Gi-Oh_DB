namespace WebPresentation.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebPresentation.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebPresentation.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebPresentation.Models.ApplicationDbContext context)
        {
            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method
            ////  to avoid creating duplicate seed data.
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            const string admin = "admin@company.com";
            const string defaultPassword = "P@ssw0rd";
            const string defaultFirstName = "Kazuki";
            const string defaultLastName = "Takahashi";
            const string defaultPhoneNumber = "1(310)220-8100";

            // before creating our first user, let's create our roles
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Judge" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Player" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Guest" });

            context.SaveChanges(); // save our newly added roles

            // now to add the admin

            if (!context.Users.Any(u => u.UserName == admin))
            {
                var user = new ApplicationUser()
                {
                    FirstName = defaultFirstName,
                    LastName = defaultLastName,
                    PhoneNumber = defaultPhoneNumber,
                    UserName = admin,
                    Email = admin
                };

                IdentityResult result = userManager.Create(user, defaultPassword);
                context.SaveChanges();

                if (result.Succeeded)
                {
                    // we created the admin, now give the admin the Admin role
                    userManager.AddToRole(user.Id, "Judge");
                    context.SaveChanges();
                }
            }
        }
    }
}
