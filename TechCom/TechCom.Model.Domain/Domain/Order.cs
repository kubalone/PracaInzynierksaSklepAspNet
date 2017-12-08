using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechCom.Model.Domain.Domain
{
   public class Order
    {
        public int OrderID { get; set; }
        public int ShippingID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual OrderDetail orderDetails { get; set; }
        public virtual Product product { get; set; }
    }
}
