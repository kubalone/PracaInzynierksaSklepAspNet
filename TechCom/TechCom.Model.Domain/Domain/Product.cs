using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCom.Model.Domain.Domain
{
   
    public class Product
    {

        public int ProductID { get; set; }
       
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }

        public DateTime  DateAdded{ get; set; }
    
        public string Description { get; set; }
        public int Quantity { get; set; }
  
        public bool ProductWithDiscount{ get; set; }

        public string ImageProduct { get; set; }


        public virtual Subcategory Subcategory { get; set; }

        
        public int SubcategoryID { get; set; }

        public virtual Category Category { get; set; }
        
        // public virtual ICollection<Category> Categories { get; set; }
    }
}
