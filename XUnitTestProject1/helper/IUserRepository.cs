using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1.helper
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        void add(User user);
        void update(User user);
    }
}
