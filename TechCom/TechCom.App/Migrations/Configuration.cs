﻿namespace TechCom.App.Migrations
{
    using Model.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model.Domain.EFRepository;
    public sealed class Configuration : DbMigrationsConfiguration<EFAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
          


        }

      
        protected override void Seed(EFAppContext context)
        {
            var categories = new List<Category>
            {
                new Category() {CategoryID=1,CategoryName="Komputery Stacjonarne" },
                new Category() {CategoryID=2,CategoryName="Laptopy" },
                new Category() {CategoryID=3,CategoryName="Dyski twarde" },
                new Category() {CategoryID=4,CategoryName="Tablety"},
                new Category() {CategoryID=5,CategoryName="Kamery" },
                new Category() {CategoryID=6,CategoryName="Klawiatury" },
                new Category() {CategoryID=7,CategoryName="Kontrolery Adaptery" },
                new Category() {CategoryID=8,CategoryName="Myszki i podkładki" },
                new Category() {CategoryID=9,CategoryName="Napędy optyczne i inne" },
                new Category() {CategoryID=10,CategoryName="Nośniki danych" },
                new Category() {CategoryID=11,CategoryName="Pamięci RAM" },
                new Category() {CategoryID=12,CategoryName="Płyty główne" },
                new Category() {CategoryID=13,CategoryName="Monitory" },
                new Category() {CategoryID=14,CategoryName="Głośniki" },
                new Category() {CategoryID=15,CategoryName="Drukarki" },
                new Category() {CategoryID=16,CategoryName="Procesory" },
                new Category() {CategoryID=17,CategoryName="Skanery" }
               


            };
            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();
            var exampleProducts = new List<Product>
            {
                new Product() {ProductID=1, CategoryID=1, Name="Asus Z370", Description="Komputer stacjonarny firmy Asus", Manufacturer="Asus", Price=2700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=2, CategoryID=2, Name="Lenovo MIIX 30-10", Description="Laptop firmy Lenovo", Manufacturer="Lenovo", Price=3700, ProductWithDiscount=false,ImageProduct="Lenovo MIIX 30-10.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=3, CategoryID=3, Name="DYSK TWARDY WD BLUE 250GB", Description="DYSK TWARDY WD BLUE 250GB 7200obr SATA 3,5''", Manufacturer="HP", Price=29, ProductWithDiscount=false,ImageProduct="WdBLUE.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=4, CategoryID=4, Name="KAMERA SPORTOWA Go-Pro HD WODOODPORNA", Description="Wielofunkcyjna kamera. Umożliwia nagrywanie filmów podczas uprawiania sportów ekstremalnych lub używania jako rejestratora jazdy w samochodzie i na motorze.", Manufacturer="GoPro", Price=200, ProductWithDiscount=false,ImageProduct="gopro.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=5, CategoryID=5, Name="Klawiatura Genesis Thor 300 TKL Blue", Description="Thor 300 TKL powstało z myślą o nich. TKL to skrót od Tenkeyless Mechanical Keyboard, czyli mechanicznej klawiatury bez części numerycznej. To właśnie kompaktowe rozmiary czynią Thor 300 TKL idealnym urządzeniem do zabrania ze sobą.", Manufacturer="Genesis", Price=70, ProductWithDiscount=true,ImageProduct="Genesis.jpg", DateAdded=DateTime.Now  },
                new Product() {ProductID=6, CategoryID=1, Name="Asus ZZ480", Description="Komputer stacjonarny Asus z systemem windows 10", Manufacturer="Asus", Price=8700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=7, CategoryID=2, Name="Asus ZZ410", Description="Laptop Asus z systemem windows 8", Manufacturer="Asus", Price=8700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   },
                new Product() {ProductID=8, CategoryID=1, Name="HP 1940", Description="Komputer z systemem windows 8", Manufacturer="HP", Price=8700, ProductWithDiscount=true,ImageProduct="AsusZ370.jpg", DateAdded=DateTime.Now   }

            };

            exampleProducts.ForEach(e => context.Products.AddOrUpdate(e));

            context.SaveChanges();
        }
    }
}
