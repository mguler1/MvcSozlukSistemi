using Business.Concrete;
using Business.ValidationRules;
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
    public class WriterPanelMessageController : Controller
    {

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator vm = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
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
            string p = (string)Session["WriterMail"];
            x.SenderMail = p;
            x.MessageDate = DateTime.Parse(DateTime.Now.ToString());
            mm.MessageAdd(x);
            return RedirectToAction("SendBox");


        }
    }
}