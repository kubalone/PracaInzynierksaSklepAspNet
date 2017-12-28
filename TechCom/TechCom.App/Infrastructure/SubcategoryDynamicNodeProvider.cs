using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechCom.Infrastructure;
using TechCom.Model.Domain.Domain;

namespace TechCom.App.Infrastructure
{
    public class SubcategoryDynamicNodeProvider : DynamicNodeProviderBase
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodeOne)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Subcategory subcategory in db.Subcategories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = subcategory.SubcategoryName;
                node.Key = "Subcategory_" + subcategory.SubcategoryID;
                node.ParentKey = "Category_" + subcategory.CategoryID;
                node.RouteValues.Add("subCategory", subcategory.SubcategoryName);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}