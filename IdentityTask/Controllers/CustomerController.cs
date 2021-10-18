using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTask.Models;

namespace IdentityTask.Controllers
{
    [Authorize(Roles = "UserCustomer")]
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Orders()
        {

            return View();
        }
        public ActionResult OrderDetails()
        {

            return View();
        }
        public new ActionResult Profile(string id)
        {
            var user = db.Users.First(a => a.Id == id);
            return View(user);
        }
       

    }
}