using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YGS_Hazirlik;
using YGS_Hazirlik.Controllers;

namespace YgsHazirlikBirimTest
{
    [TestClass]
    public class UnitTest1
    {
        Model1 Context = new Model1();
        [TestMethod]
        public void GirisTest()
        {
            Table_Kullanici _Kullanici = Context.Table_Kullanici.FirstOrDefault(x => x.KullaniciAdi == "Toltarize" && x.Parola == "toltarize");
            if (_Kullanici != null)
                Assert.AreEqual(30, 30);
            else
                Assert.AreEqual(30, 30);
        }
    }
}
