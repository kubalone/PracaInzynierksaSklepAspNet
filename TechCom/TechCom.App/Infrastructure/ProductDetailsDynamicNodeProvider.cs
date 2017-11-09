using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCom.Model.Domain.EFRepository;
using TechCom.Model.Domain.Entities;
using TechCom.Model.Domain.Repository;

namespace TechCom.App.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        EFAppContext db = new EFAppContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodeOne)
        {
            var returnValue = new List<DynamicNode>();
            foreach (var product in db.Products)
            {
                DynamicNode node = new DynamicNode();
                node.Title = product.Name;
                node.Key = "Product_" + product.ProductID;
                node.ParentKey = "Category_" + product.CategoryID;
                node.RouteValues.Add("id", product.ProductID);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}