using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.App.DAL;
using TechCom.App.Infrastructure.Helpers;
using TechCom.App.Models;
using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.Repository;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.App.Repository
{
    public class AppRepository : Controller, ICategories, IProduct
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Category> Categories
        {
            get
            {
                return context.Categories;
            }
        }


        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }
        public void EditProduct(EditProductVieModel editProduct)
        {
            context.Entry(editProduct.Product).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void SaveCategory(EditProductVieModel editProduct)
        {
            var categories = context.Categories.ToList();
            editProduct.Categories = categories;
        }

        public void SaveProduct(EditProductVieModel editProduct, string filename)
        {

            editProduct.Product.ImageProduct = filename;
            editProduct.Product.DateAdded = DateTime.Now;

            context.Entry(editProduct.Product).State = EntityState.Added;
            context.SaveChanges();

        }
        public Product DeleteProduct(int idProduct)
        {
            Product dbEntry = context.Products.Find(idProduct);
            if (dbEntry!=null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
