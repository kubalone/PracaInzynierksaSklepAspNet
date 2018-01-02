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
            var product = new Product()
            {
                ProductID = editProduct.Product.ProductID,
                Name = editProduct.Product.Name,
                Manufacturer = editProduct.Product.Manufacturer,
                DateAdded = DateTime.Now,
                Description = editProduct.Product.Description,
                Quantity = editProduct.Product.Quantity,
                ProductWithDiscount = editProduct.Product.ProductWithDiscount,
                Price = editProduct.Product.Price,
                SubcategoryID = editProduct.Product.SubcategoryID


            };
            context.Products.Attach(product);
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void SaveProduct(EditProductVieModel editProduct, string filename)
        {
           
            var product = new Product()
            {
                ProductID = editProduct.Product.ProductID,
                Name = editProduct.Product.Name,
                Manufacturer = editProduct.Product.Manufacturer,
                DateAdded = DateTime.Now,
                Description = editProduct.Product.Description,
                Quantity = editProduct.Product.Quantity,
                ProductWithDiscount = editProduct.Product.ProductWithDiscount,
                Price = editProduct.Product.Price,
                SubcategoryID = editProduct.Product.SubcategoryID,
                ImageProduct=filename,
                
                

            };
       
            //editProduct.Product.ImageProduct = filename;
            //editProduct.Product.DateAdded = DateTime.Now;

            context.Entry(product).State = EntityState.Added;
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
        //wyszukiwanie produktu
        public List <Product> SearchProduct(string searchString, List<Product> products )
        {
           var product = products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
            return product;
        }
        //zwróc produkt po id
        public Product GetProductById(int? idProduct)
        {
           var product = context.Products.FirstOrDefault(p => p.ProductID == idProduct);
           return product;

        }
        //Akcja ProductList
        //Sortowanie produktów wg kategorii
        public List<Product> SortProductByCategoryName(string categoryName)
        {
          
            var products = context.Products.Where(b => b.Subcategory.Category.CategoryName == categoryName).ToList();
            return products;
        }
        //Sortowanie produktów wg kategorii
        public List<Product> SortProductBySubcategoryName(string subCategory)
        {
            var products = context.Products.Where(p => p.Subcategory.SubcategoryName == subCategory).ToList();
            return products;
        }
        //produkty dla danej kategorii
        public List<Product> ProductByCategory(List<Product> products)
        {
            var productInCategory = products.Where(s => s.Subcategory.CategoryID == s.Subcategory.Category.CategoryID).ToList();
            return productInCategory;
        }
        //produkty dla danej podkategorii
        public List<Product> ProductBySubcategory(List<Product> products)
        {
            var productInSubcategory = products.Where(s => s.Subcategory.SubcategoryID == s.Subcategory.SubcategoryID).ToList();
            return productInSubcategory;
        }
        //produkt dla danego id
        public Product GetProductByID(int id)
        {
            var product = context.Products.Where(p => p.ProductID == id).Single();
            return product;
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
        //wyszukiwanie produktów na stronie głównej
        public List<Product> SearchProductInMainView(string searchString)
        {
            var product = context.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
            return product;
        }
        //
        //sortowanie produktów na stronie głownek
        public List<Product> OrderSearchProductInMainView(int? orderBy, List<Product> products, string searchString)
        {
            switch (orderBy)
            {
                case 1:
                    products = context.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())).OrderByDescending(p => p.Price).ToList();
                    break;
                case 2:
                    products = context.Products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())).OrderBy(p => p.Price).ToList();
                    break;
            }
            return products;
        }
        public List<CountOfProduct> CountOfProductInCategory(List<Product> categories)
        {
            var countOfProductInCategory = categories.GroupBy(c => c.Subcategory.Category.CategoryName).
                Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count(),

                }).ToList();
            List<CountOfProduct> ListOfProduct = new List<CountOfProduct>();
            for (int i = 0; i < countOfProductInCategory.ToList().Count; i++)
            {
                ListOfProduct.Add(new CountOfProduct { Categoryname = countOfProductInCategory[i].Name, Count = countOfProductInCategory[i].Count });
            }
            return ListOfProduct;
        }
        public List<CountOfProduct> CountOfProductInSubategory(List<Product> subCategories)
        {
            var countOfProductInSubcategory = subCategories.GroupBy(c => c.Subcategory.SubcategoryName).
                Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count(),

                }).ToList();
            List<CountOfProduct> ListOfProduct = new List<CountOfProduct>();
            for (int i = 0; i < countOfProductInSubcategory.ToList().Count; i++)
            {
                ListOfProduct.Add(new CountOfProduct { Categoryname = countOfProductInSubcategory[i].Name, Count = countOfProductInSubcategory[i].Count });
            }
            return ListOfProduct;
        }
    }
}
