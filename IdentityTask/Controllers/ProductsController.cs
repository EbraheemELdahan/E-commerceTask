using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityTask.Controllers
{
    public class ProductsController : Controller
    {
        // GET: UserProduct
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}