using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTask.Models;
using PagedList;

namespace IdentityTask.Controllers.Admin
{
    public class AdminCategoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: AdminCategories
        public ActionResult Index(int? page,string SortOrder)
        {
            var categories = db.Categories.ToList();
            ViewBag.NameSortParam =String.IsNullOrEmpty(SortOrder)? "name_desc":"";
            ViewBag.ProductsCountParam = SortOrder == "countProducts" ? "Prod_desc" : "countProducts";
            switch (SortOrder)
            {
                case "name_desc":
                    categories = db.Categories.OrderBy(a => a.Name).ToList();
                    break;
                case "countProducts":
                    categories = db.Categories.OrderBy(a => a.Products.Count).ToList();
                    break;
                case "Prod_desc":
                    categories = db.Categories.OrderByDescending(a => a.Products.Count).ToList();
                    break;
                default:
                    categories = db.Categories.OrderBy(a => a.ID).ToList();
                    break;



            }

            var pageNumber = page ?? 1;
            var CategoriesPerPage = categories.ToPagedList(pageNumber,3);
            ViewBag.CategoriesPerPage = CategoriesPerPage;
            return View(CategoriesPerPage);
        }
        //Get
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,CatName")]Category category,HttpPostedFileBase CatName)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                string NewImgUrl = category.ID + "." + CatName.FileName.Split('.')[1];
                CatName.SaveAs(Server.MapPath("~/Images/CategoriesImages/" + NewImgUrl));
                category.CatName = NewImgUrl;
                db.SaveChanges();
                return RedirectToAction("index", "AdminCategories");
            }
            return View(category);
        }
        public ActionResult Details(int id)
        {
            return View(db.Categories.Include("Products").FirstOrDefault(a => a.ID == id));
        }

    }
    
}