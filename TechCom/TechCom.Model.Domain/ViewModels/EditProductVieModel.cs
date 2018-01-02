using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.Model.Domain.Domain;

namespace TechCom.Model.Domain.ViewModels
{
    public class EditProductVieModel
    {
        public Product Product { get; set; }
       
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Subcategory> Subcategories { get; set; }
       
                                       

    }
}