using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeline.entity;
using Timeline.Interface;

namespace Timeline.Interface
{
    public interface IUserDao
    {
        bool CheckRegister(User user);
         bool CheckLogin(User user);
        void RegisterUser(User user);
     
    }
}
