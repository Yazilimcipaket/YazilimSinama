using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSınıflar;

namespace YGS_Hazirlik.TestClasses
{
    public class Test
    {
        Model1 Context = new Model1();
        public Boolean GirisYap(string KullaniciAdi,string Parola)
        {
            Table_Kullanici _Kullanici= Context.Table_Kullanici.FirstOrDefault(x => x.KullaniciAdi == KullaniciAdi && x.Parola == Parola);
            if (_Kullanici == null)
                return false;
            else
                return true;
        }
    }
}