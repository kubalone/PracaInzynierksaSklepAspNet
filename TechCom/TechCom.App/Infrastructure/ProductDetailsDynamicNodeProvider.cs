﻿using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCom.Infrastructure;

namespace TechCom.App.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodeOne)
        {
            var returnValue = new List<DynamicNode>();
            foreach (var product in db.Products)
            {
                DynamicNode node = new DynamicNode();
                node.Title = product.Name;
                node.Key = "Product_" + product.ProductID;
                node.ParentKey = "Subcategory_" + product.SubcategoryID;
                node.RouteValues.Add("id", product.ProductID);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}