using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timeline.server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Moq;  
using MySql.Data.MySqlClient;
using Timeline.entity;
using Timeline.Interface;

namespace Timeline.server.Tests
{
    [TestClass()]
    public class userserverTests
    {
        private UserDao server = new IUserDao();
        private Mock<MySqlConnection> connection=new Mock<MySqlConnection>();
        private Mock<MySqlCommand> mysqlCommand=new Mock<MySqlCommand>();

        [TestMethod()]
        public void checkRegisterTest()
        {

            User user = new User("lxy1", "12345");
            User user2 = new User("lxy2", "111");
        }

        [TestMethod()]
        public void checkloginTest()
        {
            User user1 = new User("lxy1", "1234");
            User user2 = new User("lxy1", "12345");
            Assert.AreEqual(server.checkLogin(user1), false);
            Assert.AreEqual(server.checkLogin(user2), true);
        }

        [TestMethod()]
        public void registerobserverTest()
        {
           

            User user1 = new User("lxy", "111");
        }

    
    }
}