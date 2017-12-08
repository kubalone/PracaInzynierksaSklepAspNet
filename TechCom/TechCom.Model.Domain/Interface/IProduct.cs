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


    }
}
