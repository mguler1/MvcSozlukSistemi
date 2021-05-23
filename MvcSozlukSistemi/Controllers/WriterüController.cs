using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSozlukSistemi.Controllers
{
    public class WriterüController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var writervalues = wm.GetList();
            return View(writervalues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer x)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(x);
            if (result.IsValid)
            {
                wm.WriterAdd(x);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}