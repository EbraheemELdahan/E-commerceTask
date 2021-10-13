using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityTask.Controllers.Admin
{
    public class AdminProductsController : Controller
    {
        // GET: AdminProducts
        public ActionResult Index()
        {
            return View();
        }
    }
}