using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCom.Model.Domain.Domain
{
    public class Subcategory
    {
        public int SubcategoryID { get; set; }
        public string SubcategoryName { get; set; }
        public virtual ICollection<Category> Categories{ get; set; }
    }
}
