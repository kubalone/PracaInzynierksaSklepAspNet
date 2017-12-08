using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using TechCom.Infrastructure;
using TechCom.Model.Domain.Domain;

using TechCom.Model.Domain.Interface;

using TechCom.Model.Domain.ViewModels;

namespace TechCom.App.Repository
{
    public class ProductRepository : Controller,IProduct
    {
        private ApplicationDbContext context = new ApplicationDbContext();

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
