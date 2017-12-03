using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Model.Domain.Repository
{
   public interface IProduct
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(EditProductVieModel product, string filename);
        void EditProduct(EditProductVieModel product);
        Product DeleteProduct(int idProduct);


    }
}
