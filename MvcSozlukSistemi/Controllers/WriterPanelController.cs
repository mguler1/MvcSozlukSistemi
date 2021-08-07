using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSozlukSistemi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
   
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(string s)
        {
            
            s = (string)Session["WriterMail"];
          var  writeridgvalues = c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterId).FirstOrDefault();
           
          //  ViewBag.d = writeridgvalues;
            var values = hm.GetListByWriter(writeridgvalues);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading x)
        {
            string m = (string)Session["WriterMail"];
            var writeridgvalues = c.Writers.Where(a => a.WriterMail == m).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.d = writeridgvalues;
            x.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            x.WriterId = writeridgvalues;
            x.HeadingStatus = true;
            hm.HeadingyAdd(x);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading x)
        {
            hm.HeadingUpdate(x);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var deleteheading = hm.GetById(id);
            deleteheading.HeadingStatus = false;
            hm.HeadingDelete(deleteheading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading()
        {
            var headings = hm.GetList();
            return View(headings);
        }
    }
}