using System.Collections.Generic;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Model.Domain.Interface
{
    public interface IProduct
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(EditProductVieModel product, string filename);
        void EditProduct(EditProductVieModel product);
        Product DeleteProduct(int idProduct);
        List<Product> SortProductByCategoryName(string categoryName);
        List<Product> SortProductBySubcategoryName(string subCategory);
        List<Product> ProductByCategory(List<Product> products);
        List<Product> ProductBySubcategory(List<Product> products);
        Product GetProductByID(int id);
        List<Product>SearchProduct(string searchString, string categoryName);
        List<Product> OrderProductInCategory(string categoryName, int? orderBy, List<Product> products);
        List<Product> OrderSearchProductInCategory(string searchString,string categoryName, int? orderBy, List<Product> products);
        List<Product> OrderProductInSubcategory(string subCategory, int? orderBy, List<Product> products);
        List<Product> SearchProductInSubCategory(string searchString, string subCategory);
        List<Product> OrderProductInSearchSubcategory(string subCategory, int? orderBy, List<Product> products, string searchString);
        List<Product> SearchProductInMainView(string searchString);
        List<Product> OrderSearchProductInMainView(int? orderBy, List<Product> products, string searchString);
        List<CountOfProduct> CountOfProductInCategory(List<Product> categories);
        List<CountOfProduct> CountOfProductInSubategory(List<Product> subCategories);
    }
}
