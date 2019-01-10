using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Timeline.entity;
using Timeline.server;

namespace TimelineTests.IntegrationTest
{
    [TestClass()]
    public class UserDaoIntegrationTests
    {
        private UserDao server;
        private IDatabase db;

        [TestInitialize]
        public void Setup()
        {
            db = new Database();
            server = new UserDao(db);
        }
        [TestMethod()]
        public void CheckRegisterTest()
        {
            User user1 = new User("lxy1", "12345");
            User user2 = new User("111", "111");
           Assert.AreEqual(server.CheckRegister(user1),true);
            Assert.AreEqual(server.CheckRegister(user2),false);
        }

        [TestMethod()]
        public void CheckLoginTest()
        {
            User user1 = new User("lxy1", "12345");
            User user2 = new User("111", "111");
            Assert.AreEqual(server.CheckLogin(user1), true);
            Assert.AreEqual(server.CheckLogin(user2), false);
        }

        [TestMethod()]
        public void RegisterUserTest()
        {
            User user1 = new User("username2", "password2");
            User user2 = new User("username3", "password3");
            server.RegisterUser(user1);
           server.RegisterUser(user2);
        }


    }
}
