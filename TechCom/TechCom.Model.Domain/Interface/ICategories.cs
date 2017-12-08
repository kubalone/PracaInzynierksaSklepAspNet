using System.Collections.Generic;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Model.Domain.Interface
{
    public interface ICategories
    {
       IEnumerable<Category> Categories{ get; }
       void SaveCategory(EditProductVieModel editProduct);
    }
}
