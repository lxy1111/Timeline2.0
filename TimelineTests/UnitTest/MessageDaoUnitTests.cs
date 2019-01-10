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
using Timeline.server;

namespace Timeline.server.Tests
{
    [TestClass()]
    public class MessageDaoUnitTests
    {

        private IMessageDao server;
        private IDatabase db;
        private Mock<IDatabase> mockDb;

        [TestInitialize]
        public void Setup()
        {
            mockDb = new Mock<IDatabase>();
            db = mockDb.Object;
            server = new MessageDao(db);
        }

        [TestMethod]
        public void GetAllNewsTest()
        {
            var mockDb = new Mock<IDatabase>();
            var sut = new MessageDao(mockDb.Object);
            var expected = new List<Message>();
            mockDb.Setup(db => db.ExecuteReader(MessageDao.GetAllNewsSql, sut.LoadMessages)).Returns(expected);
            var actual = sut.GetAllNews();
            Assert.AreEqual(expected, actual);
            mockDb.VerifyAll();
        }

        [TestMethod]
        public void LoadMessagesTest()
        {

            var user1 = new User("username1", "password1");
            var user2 = new User("username2", "password2");
            var user3 = new User("username3", "password3");
            var news1 = new Message("message1", "imageUrl1", "post_time1", user1);
            var news2 = new Message("message2", "imageUrl2", "post_time2", user2);
            var news3 = new Message("message3", "imageUrl3", "post_time3", user3);
            var mockDataReader = new Mock<IDataReader>();
            var messageList = new List<Message>();
            messageList.Add(news1);
            messageList.Add(news2);
            messageList.Add(news3);
            int count = 0;
            mockDataReader.Setup(r => r.Read()).Returns(() => count < 3).Callback(() => count++);
            mockDataReader.Setup(r => r["content"]).Returns(() => messageList[count - 1].Content);
            mockDataReader.Setup(r => r["ImageURL"]).Returns(() => messageList[count - 1].ImageUrl);
            mockDataReader.Setup(r => r["author"]).Returns(() => messageList[count - 1].User.UserName);
            mockDataReader.Setup(r => r["password"]).Returns(() => messageList[count - 1].User.UserPassword);
            mockDataReader.Setup(r => r["posttime"]).Returns(() => messageList[count - 1].PostTime);
            var mockDb = new Mock<IDatabase>();
            var sut = new MessageDao(mockDb.Object);
            var actual = sut.LoadMessages(mockDataReader.Object);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(messageList[i].Content, actual[i].Content);
                Assert.AreEqual(messageList[i].ImageUrl, actual[i].ImageUrl);
                Assert.AreEqual(messageList[i].User.UserName, actual[i].User.UserName);
                Assert.AreEqual(messageList[i].User.UserPassword, actual[i].User.UserPassword);
                Assert.AreEqual(messageList[i].PostTime, actual[i].PostTime);
            }
        }

        [TestMethod()]
        public void PublishMessageTest()
        {
            User user1 = new User("lxy1", "12345");
            Message message1 = new Message("MockContent1", "MockUrl1", "MockTime", user1);
            IDataParameter Content = new MySqlParameter();
            IDataParameter ImageUrl = new MySqlParameter();
            IDataParameter PostTime = new MySqlParameter();
            IDataParameter UserName = new MySqlParameter();
            mockDb.Setup(d => d.CreateParameter("CONTENT", message1.Content)).Returns(Content);
            mockDb.Setup(d => d.CreateParameter("IMAGE_URL", message1.ImageUrl)).Returns(ImageUrl);
            mockDb.Setup(d => d.CreateParameter("POST_TIME", message1.PostTime)).Returns(PostTime);
            mockDb.Setup(d => d.CreateParameter("USER_NAME", message1.User.UserName)).Returns(UserName);
            mockDb.Setup(d => d.ExecuteNonQuery(MessageDao.PublishMessageSql, Content, ImageUrl, PostTime, UserName)).Returns(1);
            server.PublishMessage(message1);
        }

        [TestMethod()]
        public void updateMessageInfoTest()
        {
            var user1 = new User("username1", "password1");
            var user2 = new User("username2", "password2");
            var user3 = new User("username3", "password3");
            var user4 = new User("username4", "password4");
            var user5 = new User("username5", "password5");
            var user6 = new User("username6", "password6");
            var user7 = new User("username7", "password7");
            var news1 = new Message("message1", "imageUrl1", "post_time1", user1);
            var news2 = new Message("message2", "imageUrl2", "post_time2", user2);
            var news3 = new Message("message3", "imageUrl3", "post_time3", user3);
            var news4 = new Message("message4", "imageUrl4", "post_time4", user4);
            var news5 = new Message("message5", "imageUrl5", "post_time5", user5);
            var news6 = new Message("message6", "imageUrl6", "post_time6", user6);
            var news7 = new Message("message7", "imageUrl7", "post_time7", user7);
            var mockDb = new Mock<IDatabase>();
            var sut = new MessageDao(mockDb.Object);
            var expected = new List<Message>();
            var actual = new List<MessageInfo>();
            expected.Add(news1);
            expected.Add(news2);
            expected.Add(news3);
            expected.Add(news4);
            expected.Add(news5);
            expected.Add(news6);
            expected.Add(news7);
            mockDb.Setup(db => db.ExecuteReader(MessageDao.GetAllNewsSql, sut.LoadMessages)).Returns(expected);
            actual = sut.updateMessageInfo(1);
            for (int i = 6; i >= 1; i--)
            {
                Assert.AreEqual(expected[i].Content, actual[6 - i].Content);
                Assert.AreEqual(expected[i].ImageUrl, actual[6 - i].ImageUrl);
                Assert.AreEqual(expected[i].PostTime, actual[6 - i].PostTime);
                Assert.AreEqual(expected[i].User.UserName, actual[6 - i].Username);
            }
        }

      
        
    }
}