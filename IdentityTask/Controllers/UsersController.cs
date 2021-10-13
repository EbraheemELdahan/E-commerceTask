using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTask.Models;
namespace IdentityTask.Controllers
{
    public class UsersController : Controller
    {
       ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
       // public ActionResult
    }
}