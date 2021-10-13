using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityTask.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}