using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTask.Models;
using PagedList;
using PagedList.Mvc;

namespace IdentityTask.Controllers
{
   
    public class ProductsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: UserProduct
        public ActionResult Index(int page=1)
        {
            
            
            var product = new ProductsPaginationViewModel()
            {
                Products = db.Products.OrderBy(a => a.ID),
                PoductPerPage = 3,
                CurrentPage = page
            };
            if (page < 0)
            {
                page = 1;
                product.CurrentPage = 1;
               
            }
            if (page > product.PageCount())
            {
                page = product.PageCount();
                product.CurrentPage = product.PageCount();
            }
            
            return View(product);
        }
        public ActionResult Details(int? id)
        {
            var product = db.Products.FirstOrDefault(a => a.ID == id);
            ViewBag.ProductsInSameCategory = db.Categories.FirstOrDefault(a => a.ID == product.CategoryID).Products;
            return View(product);
        }
    }
}