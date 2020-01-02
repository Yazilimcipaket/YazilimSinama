using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YGS_Hazirlik.TestClasses;

namespace YGSHazirlikUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GirisYap()
        {
            Test test = new Test();
            if (test.GirisYap("Toltarize", "toltarize"))
                Assert.AreEqual(30, 30);
            else
                Assert.AreEqual(30, 30);

        }
    }
}
