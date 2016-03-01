namespace LastBox.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LastBox.Models;
    using Microsoft.AspNet.Identity;
    using System.Collections;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<LastBox.Models.RegisteredUserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LastBox.Models.RegisteredUserDbContext context)
        {
            BoxContents contents = new BoxContents("Dan's Favorite Stuff");
            context.Boxes.AddOrUpdate(b => b.Name,
                new Box
                {
                    Name = "Test Box",
                    Category = "Boxes for Testing Purposes",
                    Cost = 25,
                    Description = "Seeded Box"

                });
        
            //if(!context.RegisteredUsers.Any(r => r.Name == "SeedUser"))
            //{
            //    RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    var userStore = new UserStore<IdentityUser>(context);
            //    var userManager = new UserManager<IdentityUser>(userStore);

            //    var registeredUser = new RegisteredUser() { Name = "SeedUser", Gender = "Male", Address = "123 Test St.", ShippingAddress = "123 Test St.", PhoneNumber = "555-5555",  };
            //    var box = new Box() { Name = "TestBox", Category = "TestCategory", Cost = 5, Description = "Generic Box" };

            //}


        }
    }
}
