using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timeline.server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MySql.Data.MySqlClient;
using Timeline.entity;
using Timeline.Interface;

namespace Timeline.server.Tests
{
    [TestClass()]
    public class UserDaoUnitTests
    {
        private IUserDao server;
        private IDatabase db;
        private Mock<IDatabase> mockDb;

        [TestInitialize]
        public void Setup()
        {
            mockDb = new Mock<IDatabase>();
            db = mockDb.Object;
            server = new UserDao(db);
        }

        [TestMethod()]
        public void CheckRegisterTest()
        {
            User user1 = new User("lxy1", "12345");
            User user2 = new User("111", "111");
            IDataParameter theParameter1 = new MySqlParameter();
            IDataParameter theParameter2 = new MySqlParameter();
            mockDb.Setup(d => d.CreateParameter("USER_NAME", user1.UserName)).Returns(theParameter1);
            mockDb.Setup(d => d.CreateParameter("USER_NAME", user2.UserName)).Returns(theParameter2);
            mockDb.Setup(d => d.ExecuteScalar(UserDao.CheckRegisterSql, theParameter1)).Returns(true);
            mockDb.Setup(d => d.ExecuteScalar(UserDao.CheckRegisterSql, theParameter2)).Returns(null);
            server.CheckRegister(user1);
            server.CheckRegister(user2);
        }

        [TestMethod()]
        public void CheckLoginTest()
        {
            User user1 = new User("lxy1", "12345");
            User user2 = new User("111", "111");
            IDataParameter username1 = new MySqlParameter();
            IDataParameter username2 = new MySqlParameter();
            IDataParameter password1 = new MySqlParameter();
            IDataParameter password2 = new MySqlParameter();
            mockDb.Setup(d => d.CreateParameter("USER_NAME", user1.UserName)).Returns(username1);
            mockDb.Setup(d => d.CreateParameter("PASSWORD", user1.UserPassword)).Returns(password1);
            mockDb.Setup(d => d.CreateParameter("USER_NAME", user2.UserName)).Returns(username2);
            mockDb.Setup(d => d.CreateParameter("PASSWORD", user1.UserPassword)).Returns(password2);
            mockDb.Setup(d => d.ExecuteScalar(UserDao.CheckLoginSql, username1,password1)).Returns(true);
            mockDb.Setup(d => d.ExecuteScalar(UserDao.CheckLoginSql, username2,password2)).Returns(null);
            server.CheckLogin(user1);
            server.CheckLogin(user2);
        }

        [TestMethod()]
        public void RegisterUserTest()
        {
            User user1 = new User("lxy1", "12345");
            IDataParameter username1 = new MySqlParameter();
            IDataParameter password1 = new MySqlParameter();
            mockDb.Setup(d => d.CreateParameter("USER_NAME", user1.UserName)).Returns(username1);
            mockDb.Setup(d => d.CreateParameter("PASSWORD", user1.UserPassword)).Returns(password1);
            mockDb.Setup(d => d.ExecuteNonQuery(UserDao.RegisterUserSql, username1, password1)).Returns(1);
            server.RegisterUser(user1);
        }
    }
}