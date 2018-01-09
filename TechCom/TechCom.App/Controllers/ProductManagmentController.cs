using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCom.App.Infrastructure.Helpers;
using TechCom.Infrastructure;
using TechCom.Model.Domain.Domain;
using TechCom.Model.Domain.Interface;
using TechCom.Model.Domain.ViewModels;

namespace TechCom.App.Controllers
{
    [Authorize]
    public class ProductManagmentController : Controller
    {
        
        private IProduct productRepository;
        private ICategories categoryRepository;
        private ISubcategories subcategoryRepository;
        private IDeliverOption deliveryRepository;
  
        public ProductManagmentController(IProduct productRepository, ICategories categoryRepository, ISubcategories subcategoryRepository, IDeliverOption deliveryRepository, ApplicationDbContext db)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.subcategoryRepository = subcategoryRepository;
            this.deliveryRepository = deliveryRepository;
           
        }
        // GET: ProductManagment
        [Authorize(Roles = "Admin")]
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
            var products = productRepository.SortByID();
            if (!String.IsNullOrEmpty(searchString))
            {
                products = productRepository.SearchProduct(searchString, products);
            }

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? idProduct)
        {
            Product product;
            //if (idCategory==null)
            //{
            //    idCategory = 1;
            //}
            if (idProduct.HasValue)
            {
                ViewBag.EditMode = true;
                product = productRepository.GetProductById(idProduct);
            }
        
            else 
            {
                ViewBag.EditMode = false;
                product =new Product();
            }
            
           var categories = categoryRepository.Categories.ToList();
           //var subcategories = subcategoryRepository.GetSubcategories(idCategory).ToList();
            var subcategories = subcategoryRepository.Subcategories.ToList();


            var model = new EditProductVieModel()
            {
                Product = product,
                Categories = categories,
                Subcategories=subcategories,
         
               
            };
           
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditProductVieModel model, HttpPostedFileBase file)
        {

            if (model.Product.ProductID > 0)
            {
                productRepository.EditProduct(model);
               
                TempData["message"] = string.Format("Zmodyfikowano ");
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
                        productRepository.SaveProduct(model, filename);
                        TempData["message"] = string.Format("Dodano ");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        categoryRepository.SaveCategory(model);
                        return View(model);
                    }
                }
                else 
                {

                    TempData["message"] = string.Format("Nie wskazano pliku ");            
                    categoryRepository.SaveCategory(model);
                    subcategoryRepository.SaveSubcategory(model);
                    return View(model);
                }
            }
        }

        [Authorize(Roles = "Admin")]
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
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    
    }
}