using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCom.Model.Domain.Entities;

namespace TechCom.App.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Category> Categories{ get; set; }
        public IEnumerable<Product> SaleProduct { get; set; }
        public Product DetailsProduct { get; set; }
        public IPagedList<Product>Products{ get; set; }
        public string CurrentCategory{ get; set; }
       

    }
}