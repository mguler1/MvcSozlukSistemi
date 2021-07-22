using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSozlukSistemi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager im = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var image = im.GetList();
            return View(image);
        }
    }
}