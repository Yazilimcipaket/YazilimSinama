using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YGS_Hazirlik.Models;

namespace YGS_Hazirlik.Controllers
{
    public class AdminController : Controller
    {
        Model1 Context = new Model1();
        public ActionResult Index()
        {
            ViewBag.KategorikOran = Context.Table_KategorikOran.Where(x => x.Kullaniciid == AktifKulanici.kullanici.Kullaniciid);
            return View(Context.Table_Test.Where(x=>x.Kullaniciid==AktifKulanici.kullanici.Kullaniciid));
        }
        public ActionResult HocaIndex()
        {
            ViewBag.Kategoriler = Context.Table_Kategoriler.ToList();
            ViewBag.kullanici = AktifKulanici.kullanici.Kullaniciid;
            return View();
        }
        [HttpPost]
        public ActionResult SoruEkle(Table_Soru sorular, HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                Bitmap ResimBoyut = new Bitmap(img, 300, 300);
                string ResimYolu = "/Content/Resimler/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                ResimBoyut.Save(Server.MapPath(ResimYolu));
                Table_Resimler rsm = new Table_Resimler();
                rsm.ResimYolu = ResimYolu;
                Context.Table_Resimler.Add(rsm);
                Context.SaveChanges();
                sorular.Resimid = rsm.Resimid;
            }
            Context.Table_Soru.Add(sorular);
            Context.SaveChanges();
            return RedirectToAction("HocaIndex");
        }

    }
}