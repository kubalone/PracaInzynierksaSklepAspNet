using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCom.Model.Domain.Domain
{
    public class DeliveryOption
    {
        [Key]
        public int DeliveryOptionID { get; set; }
        [Required(ErrorMessage = "Proszę nazwę dostawy.")]
        public string TypeOfDelivery{ get; set; }
        [Required(ErrorMessage = "Proszę podać cenę.")]
        [Range(0, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        public decimal PriceOfDelivery{ get; set; }
      
        
        
        
    }
}
