using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityTask.Controllers.Admin
{
    public class AdminCategoriesController : Controller
    {
        // GET: AdminCategories
        public ActionResult Index()
        {
            return View();
        }
    }
}