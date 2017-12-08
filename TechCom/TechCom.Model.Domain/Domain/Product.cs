using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TechCom.Model.Domain.Domain
{
    //[Bind(Include  = "ProductID, DateAdded,ImageProduct")]
    public class Product
    {
      
        //[HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        //[HiddenInput(DisplayValue = false)]
        public int CategoryID { get; set; }
        //[Display(Name = "Nazwa produktu")]
        public string Name { get; set; }
        //[Display(Name = "Cena")]
        public decimal Price { get; set; }
        //[Display(Name = "Producent")]
        public string Manufacturer { get; set; }
        //[Display(Name = "Data dodania")]
        public DateTime  DateAdded{ get; set; }
        //[DataType(DataType.MultilineText), Display(Name = "Opis")]
        public string Description { get; set; }
        public int Quantity { get; set; }
        //[Display(Name = "Produkt ze zniżką")]
        public bool ProductWithDiscount{ get; set; }
        //[Display(Name = "Zdjęcie produktu")]
        public string ImageProduct { get; set; }
      
        public virtual Category Category { get; set; }

                                           // public virtual ICollection<Category> Categories { get; set; }
    }
}
