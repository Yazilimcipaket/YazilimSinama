using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YGS_Hazirlik.Models;

namespace YGS_Hazirlik.Controllers
{
    public class SinavController : Controller
    {
        Model1 Context = new Model1();
        // GET: Sinav
        public ActionResult Index()
        {
            Table_Test test = Context.Table_Test.Where(x => x.Kullaniciid == AktifKulanici.kullanici.Kullaniciid).ToList().LastOrDefault();
            if (test != null)
            {
                if (test.Zaman.Value.Day == DateTime.Now.Day)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    test = new Table_Test();
                    test.Zaman = DateTime.Now;
                    test.Kullaniciid = AktifKulanici.kullanici.Kullaniciid;
                    Context.Table_Test.Add(test);
                    Context.SaveChanges();
                    List<Table_Soru> sorular = new List<Table_Soru>();
                    foreach (var item in Context.Table_KategorikOran.Where(x => x.Kullaniciid == AktifKulanici.kullanici.Kullaniciid))
                    {
                        int a = Convert.ToInt32(item.Oran);
                        if (a == 0)
                            a = 5;
                        else if (a == 20)
                            a = 5;
                        else if (a == 40)
                            a = 5;
                        else if (a == 60)
                            a = 3;
                        else
                            a = 1;

                        foreach (Table_Soru item2 in item.Table_Kategoriler.Table_Soru.Take(a))
                        {
                            sorular.Add(item2);
                        }
                    }
                    return View(sorular);
                }

            }
            else
            {
                test = new Table_Test();
                test.Zaman = DateTime.Now;
                test.Kullaniciid = AktifKulanici.kullanici.Kullaniciid;
                Context.Table_Test.Add(test);
                Context.SaveChanges();
                List<Table_Soru> sorular = new List<Table_Soru>();
                foreach (var item in Context.Table_Soru.GroupBy(x => x.Table_Kategoriler).ToList())
                {
                    foreach (Table_Soru item2 in item.Take(5))
                    {
                        sorular.Add(item2);
                    }
                }
                return View(sorular);
            }
        }
        [HttpPost]
        public void Kontrol(int id, string name)
        {
            Table_Soru soru = Context.Table_Soru.FirstOrDefault(x => x.Soruid == id);
            Table_Test test = Context.Table_Test.FirstOrDefault(x => x.Kullaniciid == AktifKulanici.kullanici.Kullaniciid &&
            x.Zaman.Value.Day == DateTime.Now.Day);

            Table_KategorikOran kategorikOran = Context.Table_KategorikOran.FirstOrDefault(x => x.Kategoriid == soru.Kategoriid &&
            x.Kullaniciid == AktifKulanici.kullanici.Kullaniciid &&
            x.Table_Test.Zaman.Value.Day == DateTime.Now.Day);
            if (kategorikOran == null)
            {
                Table_KategorikOran kategorikoran = new Table_KategorikOran();
                kategorikoran.Kullaniciid = AktifKulanici.kullanici.Kullaniciid;
                kategorikoran.Kategoriid = soru.Kategoriid;
                kategorikoran.Testid = test.Testid;
                kategorikoran.Oran = 0;
                if (soru.DogruCevap == name)
                    kategorikoran.Oran = kategorikoran.Oran + 20;
                Context.Table_KategorikOran.Add(kategorikoran);
                Context.SaveChanges();
            }
            else
            {
                Table_SoruCevap SoruCevap = Context.Table_SoruCevap.FirstOrDefault(x => x.Soruid == soru.Soruid && x.Testid == test.Testid);
                if (SoruCevap == null)
                {
                    if (soru.DogruCevap == name)
                        kategorikOran.Oran = kategorikOran.Oran + 20;
                }
                else
                {
                    if (soru.DogruCevap == name)
                        kategorikOran.Oran = kategorikOran.Oran + 20;
                    else
                    {
                        if (SoruCevap.Dogruluk != false)
                            kategorikOran.Oran = kategorikOran.Oran - 20;

                    }

                }

                Context.SaveChanges();
            }
            Table_SoruCevap soruCevap = Context.Table_SoruCevap.FirstOrDefault(x => x.Soruid == id);
            if (soruCevap == null)
            {
                soruCevap = new Table_SoruCevap();
                if (soru.DogruCevap == name)
                {
                    soruCevap.Testid = test.Testid;
                    soruCevap.Soruid = soru.Soruid;
                    soruCevap.Dogruluk = true;
                    Context.Table_SoruCevap.Add(soruCevap);
                    Context.SaveChanges();
                }
                else
                {
                    soruCevap.Testid = test.Testid;
                    soruCevap.Soruid = soru.Soruid;
                    soruCevap.Dogruluk = false;
                    Context.Table_SoruCevap.Add(soruCevap);
                    Context.SaveChanges();
                }
            }
            else
            {
                if (soru.DogruCevap == name)
                {
                    soruCevap.Testid = test.Testid;
                    soruCevap.Soruid = soru.Soruid;
                    soruCevap.Dogruluk = true;
                    Context.SaveChanges();
                }
                else
                {
                    soruCevap.Testid = test.Testid;
                    soruCevap.Soruid = soru.Soruid;
                    soruCevap.Dogruluk = false;
                    Context.SaveChanges();
                }
            }
        }
    }
}