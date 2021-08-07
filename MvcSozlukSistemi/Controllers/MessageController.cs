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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator vm = new MessageValidator();
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListInbox( p);
            return View(messagelist);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var messagedetails = mm.GetById(id);
            return View(messagedetails);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messagedetails = mm.GetById(id);
            return View(messagedetails);
        }
        public ActionResult Sendbox(string p)
        {
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        [HttpGet]
        public ActionResult AddNewMessage() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewMessage(Message x)
        {
            //ValidationResult result = vm.Validate(x);
            //if (result.IsValid)
            //{
            //    x.MessageDate =DateTime.Parse(DateTime.Now.ToString());
            //    mm.MessageAdd(x);
            //    return RedirectToAction("SendBox");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            x.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                mm.MessageAdd(x);
                return RedirectToAction("SendBox");
           

        }

    }
}