using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCom.Model.Domain.Domain
{
    public class ShoppingCart
    {
        public Product Product { get; set; }
        public decimal Worth { get; set; }
        public int Quantity { get; set; }
    }
}
