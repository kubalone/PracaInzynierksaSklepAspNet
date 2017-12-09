using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechCom.Model.Domain.Domain
{
    public class Category
    {
        
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
         public virtual ICollection<Subcategory> Subcategory { get; set; }
        //public virtual ICollection<Product> Product { get; set; }

    }
}