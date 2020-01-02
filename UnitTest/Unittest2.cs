using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTest.Helper2;
using YGS_Hazirlik;

namespace UnitTest
{
  public  class Unittest2
    {
        KullaniciOperasyon operations = new KullaniciOperasyon();
        public readonly IkullaniciRepository _repository;
        public Unittest2()
        {
            var userList = new List<Kullanici>
            {
                new Kullanici { KullaniciAdi = "Toltarize", Parola = "toltarize" },
                new Kullanici { KullaniciAdi = "Erkmen", Parola = "erkmen" }
            };

            var mockUserRepository = new Mock<IkullaniciRepository>();
            mockUserRepository.Setup(mr => mr.GetAll()).Returns(userList);
            mockUserRepository.Setup(mr => mr.Add(It.IsAny<Kullanici>())).Callback(
                (Kullanici user) =>
                {
                    userList.Add(user);
                });
            mockUserRepository.Setup(mr => mr.Update(It.IsAny<Kullanici>())).Callback(
                (Kullanici user) =>
                {
                    var originalUser = userList.Where(q => q.KullaniciAdi == user.KullaniciAdi&&q.Parola==user.Parola).Single();

                    if (originalUser == null)
                        throw new InvalidOperationException();

                    originalUser.KullaniciAdi = user.KullaniciAdi;
                    originalUser.Parola = user.Parola;
                });

            this._repository = mockUserRepository.Object;
        }

        [Test]
        public void Login()
        {
            var isUserExist = operations.IsUserExist("Toltarize", "toltarize");

            if (isUserExist)
                Assert.Pass("User exist");

            else
                Assert.Fail("User is not exist");
        }

        [Test]
        public void AddUser()
        {
            var actual = this._repository.GetAll().Count + 1;
            var user = new Kullanici {KullaniciAdi = "Admin", Parola = "Admin" };

            this._repository.Add(user);
            var expectedUserCount = this._repository.GetAll().Count;

            Assert.AreEqual(actual, expectedUserCount);
        }

        [Test]
        public void UpdateUser()
        {
            var user = new Kullanici { KullaniciAdi = "Toltarize", Parola = "toltarize" };
            this._repository.Update(user);

            var expected = this._repository
                .GetAll().FirstOrDefault(p => p.KullaniciAdi==user.KullaniciAdi&&p.Parola==user.Parola);

            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.KullaniciAdi, user.KullaniciAdi);
            Assert.AreEqual(expected.Parola, user.Parola);
        }
    }
}