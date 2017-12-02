using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCom.Model.Domain.Entities
{
   public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public DateTime  DateAdded{ get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool ProductWithDiscount{ get; set; }
        public string ImageProduct { get; set; }

        public virtual Category Category { get; set; }


    }
}
