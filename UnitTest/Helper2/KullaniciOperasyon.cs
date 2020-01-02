using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Helper2
{
   public class KullaniciOperasyon
    {
        private readonly Kullanici kullanici;
        public KullaniciOperasyon()
        {
            kullanici = new Kullanici
            {
                KullaniciAdi = "Toltarize",
                Parola = "toltarize"
            };
        }
        public bool IsUserExist(string username, string password)
        {
            return true
                ? username == kullanici.KullaniciAdi && password == kullanici.Parola
                : false;
        }
    }
}
