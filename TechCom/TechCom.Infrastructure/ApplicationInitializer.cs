using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using TechCom.Model.Domain.Domain;
using TechCom.Infrastructure.Migrations;

namespace TechCom.Infrastructure
{
    public class ApplicationInitializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>
    {
        public static void SeedAppData(ApplicationDbContext context)
        {
            var categories = new List<Category>
            {
                new Category() {CategoryID=5,CategoryName="Drukarki tusze tonery"},
                new Category() {CategoryID=4,CategoryName="Dyski twarde i akcesoria" },
                new Category() {CategoryID=8,CategoryName="Głośniki słuchawki mikrofony" },
                new Category() {CategoryID=9,CategoryName="Karty Graficzne" },
                new Category() {CategoryID=10,CategoryName="Karty muzyczne" },
                new Category() {CategoryID=7,CategoryName="Klawiatury" },
                new Category() {CategoryID=1,CategoryName="Komputery Stacjonarne" },
                new Category() {CategoryID=3,CategoryName="Laptopy" },
                new Category() {CategoryID=2,CategoryName="Monitory" },
                new Category() {CategoryID=11,CategoryName="Myszki i podkładki" },
                new Category() {CategoryID=12,CategoryName="Napędy optyczne i inne" },
                new Category() {CategoryID=13,CategoryName="Pamięci RAM" },
                new Category() {CategoryID=15,CategoryName="Pamięci Flash" },
                new Category() {CategoryID=14,CategoryName="Płyty głowne" },
                new Category() {CategoryID=6,CategoryName="Procesory" },



            };
            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();

            var subcategories = new List<Subcategory>
            {
                new Subcategory() {SubcategoryID=1,SubcategoryName="All in One", CategoryID=1 },
                new Subcategory() {SubcategoryID=2,SubcategoryName="Nettopy/Mini-PC", CategoryID=1 },
                new Subcategory() {SubcategoryID=3,SubcategoryName="Desktopy", CategoryID=1 },

                new Subcategory() {SubcategoryID=4,SubcategoryName="Monitory LED 21,9' i mniejsze", CategoryID=2 },
                new Subcategory() {SubcategoryID=5,SubcategoryName="Monitory LED 2''- 23,9'", CategoryID=2 },
                new Subcategory() {SubcategoryID=6,SubcategoryName="Monitory LED 24' - 26,9'", CategoryID=2 },
                new Subcategory() {SubcategoryID=7,SubcategoryName="Monitory LED 27' - 28,9'", CategoryID=2 },
                new Subcategory() {SubcategoryID=8,SubcategoryName="Monitory LED 29'' - 31,9'", CategoryID=2 },
                new Subcategory() {SubcategoryID=9,SubcategoryName="Monitory LED 32' i większe'", CategoryID=2 },

                new Subcategory() {SubcategoryID=10,SubcategoryName="Notebooki, Laptopy", CategoryID=3 },
                new Subcategory() {SubcategoryID=11,SubcategoryName="Torby i plecaki", CategoryID=3 },
                new Subcategory() {SubcategoryID=12,SubcategoryName="Akcesoria do laptopów", CategoryID=3 },
                new Subcategory() {SubcategoryID=13,SubcategoryName="Zasilacze do laptopa uniwersalne", CategoryID=3 },
                new Subcategory() {SubcategoryID=14,SubcategoryName="Zasilacze do laptopa dedykowane", CategoryID=3 },
                new Subcategory() {SubcategoryID=15,SubcategoryName="Baterie do laptopa", CategoryID=3 },

                new Subcategory() {SubcategoryID=16,SubcategoryName="Dyski twarde SATA", CategoryID=4 },
                new Subcategory() {SubcategoryID=17,SubcategoryName="Dyski twarde USB zewnętrzne", CategoryID=4 },
                new Subcategory() {SubcategoryID=18,SubcategoryName="Dyski SSD", CategoryID=4 },
                new Subcategory() {SubcategoryID=19,SubcategoryName="Dyski twarde 2,5 cala", CategoryID=4 },

                new Subcategory() {SubcategoryID=20,SubcategoryName="Drukarki atramentowe", CategoryID=5 },
                new Subcategory() {SubcategoryID=21,SubcategoryName="Drukarki laserowe", CategoryID=5 },
                new Subcategory() {SubcategoryID=22,SubcategoryName="Drukarki igłowe", CategoryID=5 },
                new Subcategory() {SubcategoryID=23,SubcategoryName="Atramenty do drukarek Brother", CategoryID=5 },
                new Subcategory() {SubcategoryID=24,SubcategoryName="Atramenty do drukarek Canon", CategoryID=5 },
                new Subcategory() {SubcategoryID=25,SubcategoryName="Atramenty do drukarek HP", CategoryID=5 },
                new Subcategory() {SubcategoryID=26,SubcategoryName="Tonery do drukarek HP", CategoryID=5 },
                new Subcategory() {SubcategoryID=27,SubcategoryName="Tonery do drukarek Canon", CategoryID=5 },
                new Subcategory() {SubcategoryID=28,SubcategoryName="Tonery do drukarek Samsung", CategoryID=5 },
                new Subcategory() {SubcategoryID=29,SubcategoryName="Tonery do drukarek Lexmark", CategoryID=5 },

                new Subcategory() {SubcategoryID=30,SubcategoryName="Procesory AMD AM4", CategoryID=6 },
                new Subcategory() {SubcategoryID=31,SubcategoryName="Procesory Intel xeon", CategoryID=6 },
                new Subcategory() {SubcategoryID=32,SubcategoryName="Procesory Intel socket 2011", CategoryID=6 },
                new Subcategory() {SubcategoryID=33,SubcategoryName="Procesory Intel socket 1151", CategoryID=6 },
                new Subcategory() {SubcategoryID=34,SubcategoryName="Procesory AMD socket FM2", CategoryID=6 },
                new Subcategory() {SubcategoryID=35,SubcategoryName="Procesory Intel socket 1150", CategoryID=6 },

                new Subcategory() {SubcategoryID=36,SubcategoryName="Klawiatory bezprzwodowe", CategoryID=7 },
                new Subcategory() {SubcategoryID=37,SubcategoryName="Klawiatury przewodowe", CategoryID=7 },

                new Subcategory() {SubcategoryID=38,SubcategoryName="Głośniki", CategoryID=8 },
                new Subcategory() {SubcategoryID=39,SubcategoryName="Słuchawki", CategoryID=8 },
                new Subcategory() {SubcategoryID=40,SubcategoryName="Mikrofony", CategoryID=8 },

                new Subcategory() {SubcategoryID=41,SubcategoryName="Karty graficzne PCI-E", CategoryID=9 },
                new Subcategory() {SubcategoryID=42,SubcategoryName="Chłodzenie kart graficznych", CategoryID=9 },

                new Subcategory() {SubcategoryID=43,SubcategoryName="Karty muzyczne", CategoryID=10 },

                new Subcategory() {SubcategoryID=44,SubcategoryName="Myszki", CategoryID=11 },
                new Subcategory() {SubcategoryID=45,SubcategoryName="Podkładki pod myszki", CategoryID=11 },

                new Subcategory() {SubcategoryID=46,SubcategoryName="Blu-Ray", CategoryID=12 },
                new Subcategory() {SubcategoryID=47,SubcategoryName="Nagrywarki", CategoryID=12 },
                new Subcategory() {SubcategoryID=48,SubcategoryName="Odtwarzacze DVD", CategoryID=12 },
                new Subcategory() {SubcategoryID=49,SubcategoryName="Napędy FDD", CategoryID=12 },

                new Subcategory() {SubcategoryID=50,SubcategoryName="DDR", CategoryID=13 },
                new Subcategory() {SubcategoryID=51,SubcategoryName="DDR2", CategoryID=13 },
                new Subcategory() {SubcategoryID=52,SubcategoryName="DDR3", CategoryID=13 },
                new Subcategory() {SubcategoryID=53,SubcategoryName="DDR4", CategoryID=13 },

                new Subcategory() {SubcategoryID=54,SubcategoryName="Płyty główne AMD Socket AM4", CategoryID=14 },
                new Subcategory() {SubcategoryID=55,SubcategoryName="Płyty główne AMD socket AM3", CategoryID=14 },
                new Subcategory() {SubcategoryID=56,SubcategoryName="Płyty główne AMD socket FM2", CategoryID=14 },
                new Subcategory() {SubcategoryID=57,SubcategoryName="Procesory Intel xeon", CategoryID=14 },
                new Subcategory() {SubcategoryID=58,SubcategoryName="Płyty główne Raspberry PI", CategoryID=14 },
                new Subcategory() {SubcategoryID=59,SubcategoryName="Płyty główne LGA 2066", CategoryID=14 },

                new Subcategory() {SubcategoryID=57,SubcategoryName="Pamięci do aparatów cyfrowych", CategoryID=15 },
                new Subcategory() {SubcategoryID=58,SubcategoryName="Pamięci - Pendrive", CategoryID=15 },
                new Subcategory() {SubcategoryID=59,SubcategoryName="Czytniki pamięci", CategoryID=15 },


            };
            subcategories.ForEach(c => context.Subcategories.AddOrUpdate(c));
            context.SaveChanges();

            var exampleProducts = new List<Product>
            {

                new Product() {ProductID=1, SubcategoryID=1, Name="Asus All in One", Description="",Quantity=10, Manufacturer="Asus", Price=2700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=10, SubcategoryID=1, Name="Lenovo II All in One", Description="",Quantity=10, Manufacturer="Asus", Price=2700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=11, SubcategoryID=1, Name="Asus III All in One", Description="",Quantity=10, Manufacturer="Asus", Price=2700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },

                new Product() {ProductID=2, SubcategoryID=2, Name="Lenovo All Nettopy/Mini-PC", Description="",Quantity=10, Manufacturer="Lenovo", Price=3700, ProductWithDiscount=false,ImageProduct="Lenovo MIIX 30-10.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=12, SubcategoryID=2, Name="Asus II Nettopy/Mini-PC", Description="",Quantity=10, Manufacturer="Lenovo", Price=3700, ProductWithDiscount=false,ImageProduct="Lenovo MIIX 30-10.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=13, SubcategoryID=2, Name="Lenovo III Nettopy/Mini-PC", Description="",Quantity=10, Manufacturer="Lenovo", Price=3700, ProductWithDiscount=false,ImageProduct="Lenovo MIIX 30-10.jpg", DateAdded=DateTime.Now   },


                new Product() {ProductID=3, SubcategoryID=4, Name="Pordukt Monitory LED 21,9' i mniejsze", Description="",Quantity=10, Manufacturer="HP", Price=29, ProductWithDiscount=false,ImageProduct="WdBLUE.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=4, SubcategoryID=4, Name="Pordukt Monitory LED 21,9' i mniejsze", Description="",Quantity=10, Manufacturer="GoPro", Price=200, ProductWithDiscount=false,ImageProduct="gopro.jpg", DateAdded=DateTime.Now   },

                new Product() {ProductID=5, SubcategoryID=10, Name="Pordukt Notebooki, Laptopy", Description="",Quantity=10, Manufacturer="Genesis", Price=70, ProductWithDiscount=true,ImageProduct="Genesis.jpg", DateAdded=DateTime.Now  },
                new Product() {ProductID=6, SubcategoryID=11, Name="Pordukt Torby i plecaki", Description="",Quantity=10, Manufacturer="Asus", Price=8700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },

                new Product() {ProductID=7, SubcategoryID=16, Name="Dyski twarde SATA", Description="",Quantity=10, Manufacturer="Asus", Price=8700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=8, SubcategoryID=17, Name="Dyski twarde USB zewnętrzne", Description="",Quantity=10, Manufacturer="HP", Price=8700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=9, SubcategoryID=18, Name="Dyski SSD", Description="",Quantity=10, Manufacturer="HP", Price=8700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   }

            };

            exampleProducts.ForEach(e => context.Products.AddOrUpdate(e));

            context.SaveChanges();
        }
        public static void SeedUserData(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string userName = "admin@techCom.pl";
            const string password = "Qwer11!";
            const string roleName = "Admin";

            var user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true,
                    UserData = new UserData()
                };
                var result = userManager.Create(user, password);
            }
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}