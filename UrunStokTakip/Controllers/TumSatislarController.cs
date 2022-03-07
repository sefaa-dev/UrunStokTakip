using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    public class TumSatislarController : Controller
    {
        // GET: TumSatislar
        Takip_SistemiEntities db = new Takip_SistemiEntities();
        [Authorize(Roles = "A")]

        public ActionResult Index(int sayfa=1)
        {
            return View(db.Satislar.ToList().ToPagedList(sayfa,5));
        }
    }
}