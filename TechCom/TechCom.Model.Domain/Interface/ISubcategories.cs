using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.Model.Domain.Interface
{
    public interface ISubcategories
    {
        IEnumerable<Subcategory> Subcategories{ get; }
        void SaveSubcategory(EditProductVieModel editProduct);
    }
}
