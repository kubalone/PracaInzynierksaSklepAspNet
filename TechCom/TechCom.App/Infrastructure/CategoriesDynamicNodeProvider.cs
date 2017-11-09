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
    public class CategoriesDynamicNodeProvider : DynamicNodeProviderBase
    {
        EFAppContext db = new EFAppContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodeOne)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Category category in db.Categories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = category.CategoryName;
                node.Key = "Category_" + category.CategoryID;
                node.RouteValues.Add("categoryName", category.CategoryName);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}