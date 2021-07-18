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
    public class AboutController : Controller
    {
        // GET: About
        AboutManager amanager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalue = amanager.GetList();
            return View(aboutvalue);
        }
        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutAdd(About x)
        {
            amanager.AboutAdd(x);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}