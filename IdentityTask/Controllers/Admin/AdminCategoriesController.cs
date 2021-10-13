using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTask.Models;

namespace IdentityTask.Controllers.Admin
{
    public class AdminCategoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: AdminCategories
        public ActionResult Index()
        {
            
            return View(db.Categories.ToList());
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
    
           
    }
    
}