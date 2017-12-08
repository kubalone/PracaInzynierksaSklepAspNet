using System.Collections.Generic;

namespace TechCom.Model.Domain.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products{ get; set; }

    }
}