using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.App.Infrastructure.Helpers;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.App.Controllers
{
    public class ProductManagmentController : Controller
    {
        private IProduct productRepository;
        private ICategories categoryRepository;
        private ISubcategories subcategoryRepository;
        public ProductManagmentController(IProduct productRepository, ICategories categoryRepository, ISubcategories subcategoryRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.subcategoryRepository = subcategoryRepository;
        }
        

        // GET: ProductManagment
        public ViewResult Index(string currentFilter, string searchString, int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var products = productRepository.Products;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            return View(products.OrderBy(p=>p.ProductID).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Edit(int? idProduct,int? idCategory)
        {
            Product product;
            if (idCategory==null)
            {
                idCategory = 1;
            }
            if (idProduct.HasValue)
            {
                ViewBag.EditMode = true;
                product = productRepository.Products.FirstOrDefault(p => p.ProductID == idProduct);
            }
        
            else 
            {
                ViewBag.EditMode = false;
                product =new Product();
            }
            
           var categories = categoryRepository.Categories.ToList();
           var subcategories = subcategoryRepository.Subcategories.Where(p=>p.CategoryID==idCategory&&p.SubcategoryName!=null).ToList();
           var model = new EditProductVieModel()
            {
                Product = product,
                Categories = categories,
                Subcategories=subcategories
               
            };
           
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditProductVieModel editProduct, HttpPostedFileBase file)
        {

            if (editProduct.Product.ProductID > 0)
            {
                productRepository.EditProduct(editProduct);
                
                return RedirectToAction("Index");
            }
            else
            {
                
                if (file != null && file.ContentLength > 0)
                {
                    if (ModelState.IsValid)
                    {

                        var fileExt = Path.GetExtension(file.FileName);
                        var filename = Guid.NewGuid() + fileExt;

                        var path = Path.Combine(Server.MapPath(ImageConfig.ImageSource), filename);
                        file.SaveAs(path);
                        productRepository.SaveProduct(editProduct, filename);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        categoryRepository.SaveCategory(editProduct);
                        return View(editProduct);
                    }
                }
                else
                {
                    TempData["message"] = string.Format("Nie wskazano pliku ", editProduct);
                    categoryRepository.SaveCategory(editProduct);
                   
                    return View(editProduct);
                }
            }

  
        }
       
        public ActionResult Delete(int idProduct)
        {
            Product deleteProduct = productRepository.DeleteProduct(idProduct);
            if (deleteProduct!=null)
            {
                TempData["message"] = string.Format("Usunięto ", deleteProduct.Name);
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetSubCategoryById(int CategoryID)
        {
            var items = from c in subcategoryRepository.Subcategories
                        where c.CategoryID==CategoryID&&c.SubcategoryName!=null
                        select new
                        {
                            Value = c.SubcategoryID,
                            Text = c.SubcategoryName
                        };
            //var subcategory = subcategoryRepository.Subcategories.Where(p => p.CategoryID == CategoryID).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
       

    }
}