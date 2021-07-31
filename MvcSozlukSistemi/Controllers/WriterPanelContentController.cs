using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSozlukSistemi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult MyContent(int id)
        {
            var contentvalues = cm.GetListById(id);
            return View(contentvalues);
         
        }
    }
}