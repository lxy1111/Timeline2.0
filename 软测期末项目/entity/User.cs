using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeline.Interface;
using Timeline.server;


namespace Timeline.entity
{
   public  class User 
    {
        public string UserName { get; }
        public string UserPassword { get; }
      
        public  User(string username,string password)
        {
            this.UserName = username;
            this.UserPassword = password;
        }
    }
}
