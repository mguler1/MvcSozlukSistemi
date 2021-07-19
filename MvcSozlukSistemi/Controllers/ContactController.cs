using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSozlukSistemi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
           var message= cm.GetList();
            return View(message);
        }
        public ActionResult GetContactDetails(int id)
        {
            var messagedetails = cm.GetById(id);
            return View(messagedetails);
        }
        public PartialViewResult MessageMenu()
        {
            return PartialView();
        }
    }
}