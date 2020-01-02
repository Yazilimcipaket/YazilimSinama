using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Helper2
{
    public interface IkullaniciRepository
    {
        IList<Kullanici> GetAll();
        void Add(Kullanici kullanici);
        void Update(Kullanici kullanici);
    }
}
