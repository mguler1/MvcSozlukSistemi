using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSozlukSistemi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
       AdminManager lm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var admin = lm.GetList();
            return View(lm);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin a)
        {
            lm.AdminAdd(a);
            return RedirectToAction("Index");

        }
    }
}