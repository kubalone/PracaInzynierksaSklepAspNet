﻿using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.Model.Domain.Entities;

namespace TechCom.App.Models
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            OrderList = new List<SelectListItem>();
        }
        public List<CountOfProduct> CountOfProductsInCategory{ get; set; }//id produktu w autowyszukiwaniu
        [Display(Name = "Sortuj wg: ")]
        public int? OrderBy { get; set; }
        public IEnumerable<SelectListItem> OrderList { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public IEnumerable<Category> Categories{ get; set; }
        public IEnumerable<Product> EnableCategories { get; set; }//lista dostepnych kategorii dla danego produktu
      
        public IEnumerable<Product> SaleProduct { get; set; }
        public Product DetailsProduct { get; set; }
        public IPagedList<Product>Products{ get; set; }
        public string CurrentCategory{ get; set; }
       

    }
}