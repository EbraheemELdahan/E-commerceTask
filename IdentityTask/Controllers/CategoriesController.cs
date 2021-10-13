using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTask.Models;

namespace IdentityTask.Controllers
{

    public class CategoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
    }
}