using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        //wyszukiwanie produktów
        public List<Product> SearchProduct(string searchString, string categoryName)
        {
            var product = context.Products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()) && p.Subcategory.Category.CategoryName == categoryName).ToList();
            return product;
        }
        //sortowanie produktów w kateogrii
        public List<Product> OrderProductInCategory(string categoryName, int? orderBy,List<Product> products)
        {     
            switch (orderBy)
            {
                case 1:
               products = context.Products.Where(p => p.Subcategory.Category.CategoryName == categoryName).OrderByDescending(p => p.Price).ToList();
                    break;
               case 2:
                products = context.Products.Where(p => p.Subcategory.Category.CategoryName == categoryName).OrderBy(p => p.Price).ToList();
                    break;
            }
            return products;
        }
        //sortowanie wyszukanych produktów w kategorii
        public List<Product> OrderSearchProductInCategory(string searchString,string categoryName, int? orderBy, List<Product> products)
        {
            switch (orderBy)
            {
                case 1:
                    products = context.Products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()) &&  p.Subcategory.Category.CategoryName == categoryName).OrderByDescending(p => p.Price).ToList();
                    break;
                case 2:
                    products = context.Products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()) && p.Subcategory.Category.CategoryName == categoryName).OrderBy(p => p.Price).ToList();
                    break;
            }
            return products;
        }
        //sortowanie produktów w podkategorii
        public List<Product> OrderProductInSubcategory(string subCategory, int? orderBy, List<Product> products)
        {
            switch (orderBy)
            {
                case 1:
                    products = context.Products.Where(p => p.Subcategory.SubcategoryName== subCategory).OrderByDescending(p => p.Price).ToList();
                    break;
                case 2:
                    products = context.Products.Where(p => p.Subcategory.SubcategoryName == subCategory).OrderBy(p => p.Price).ToList();
                    break;
            }
            return products;
        }
        //wyszukiwanie produktów w podkategorii
        public List<Product> SearchProductInSubCategory(string searchString, string subCategory)
        {
            var product = context.Products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()) && p.Subcategory.SubcategoryName == subCategory).ToList();
            return product;
        }
        //sortowanie wyszukanych produktów w podkategorii
        public List<Product> OrderProductInSearchSubcategory(string subCategory, int? orderBy, List<Product> products,string searchString)
        {
            switch (orderBy)
            {
                case 1:
                    products = context.Products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()) && p.Subcategory.SubcategoryName == subCategory).OrderByDescending(p => p.Price).ToList();
                    break;
                case 2:
                    products = context.Products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()) &&  p.Subcategory.SubcategoryName == subCategory).OrderBy(p => p.Price).ToList();
                    break;
            }
            return products;
        }
    }
}
