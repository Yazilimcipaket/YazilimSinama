using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YGS_Hazirlik.Models;

namespace YGS_Hazirlik.Controllers
{
    public class HomeController : Controller
    {
        Model1 Context = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kullaniciadi,string parola)
        {
            Table_Kullanici kullanici =Context.Table_Kullanici.FirstOrDefault(x => x.KullaniciAdi == kullaniciadi && x.Parola == parola);
            AktifKulanici.kullanici = kullanici;
            if (kullanici != null)
            {
                if (kullanici.Table_Rol.RolAdi == "Ogretmen")
                    return RedirectToAction("/HocaIndex", "Admin");
                return RedirectToAction("/Index", "Admin");
            }
            else
                return RedirectToAction("Index");
        }
    }
}