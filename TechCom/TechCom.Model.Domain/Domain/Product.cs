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
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu")]
        [StringLength(100)]      
        public string Name { get; set; }

        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę producenta.")]
        [StringLength(100)]
        public string Manufacturer { get; set; }

        public DateTime DateAdded { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Proszę podać opis.")]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public bool ProductWithDiscount { get; set; }

        public string ImageProduct { get; set; }


        public virtual Subcategory Subcategory { get; set; }

        public int SubcategoryID { get; set; }
        

        
    }

}
