using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Takip_SistemiEntities db = new Takip_SistemiEntities();

        [Authorize]
        public ActionResult Index()
        {
            var list = db.Urun.ToList();
            return View(list);
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Urun Data, HttpPostedFileBase File)
        {
            string path = Path.Combine("~/Content/Image" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            Data.Resim = File.FileName.ToString();
            db.Urun.Add(Data);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}