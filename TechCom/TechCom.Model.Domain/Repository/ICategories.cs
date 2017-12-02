using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Model.Domain.Repository
{
    public interface ICategories
    {
       IEnumerable<Category> Categories{ get; }
        void SaveCategory(EditProductVieModel editProduct);
    }
}
