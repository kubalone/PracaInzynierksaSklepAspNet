using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCom.Model.Domain.Domain
{
    public class Subcategory
    {
       [Key]
        public int SubcategoryID { get; set; }
      
        public string SubcategoryName { get; set; }
        public virtual Category Category { get; set; }      
        public int CategoryID { get; set; }
       
        public virtual ICollection<Product> Product { get; set; }
    }
}
