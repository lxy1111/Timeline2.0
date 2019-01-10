using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MySql.Data.MySqlClient;
using Timeline.entity;
using Timeline.Interface;
using Timeline.server;

namespace TimelineTests.IntegrationTest
{
    [TestClass()]
    public class MessageDaoIntegrationTests
    {

        private MessageDao server;
        private IDatabase db;
      

        [TestInitialize]
        public void Setup()
        { 
            db=new Database();
            server = new MessageDao(db);
        }

        [TestMethod]
        public void GetAllNewsTest()
        {
            var actual = server.GetAllNews();           
        }


        [TestMethod()]
        public void PublishMessageTest()
        {
            User user1=new User("lxy1","12345"); 
            Message news1 = new Message("content2","imageUrl2","postTime2",user1);
            server.PublishMessage(news1);
        }

        [TestMethod()]
        public void updateMessageInfoTest()
        {
            var list1=server.updateMessageInfo(0);
            var list2=server.updateMessageInfo(1);
            var list3=server.updateMessageInfo(2);
            var list4 = server.updateMessageInfo(3);
            var list5 = server.updateMessageInfo(4);
            var list6 = server.updateMessageInfo(5);
        }
    } 
}
