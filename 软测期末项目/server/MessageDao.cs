using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Timeline.entity;
using Timeline.Interface;
using Timeline.server;

namespace Timeline.server
{
    public class MessageDao : IMessageDao
    {
        private IDatabase db;
        private List<Message> newsList = new List<Message>();
        private static List<MessageInfo> messageInfos = new List<MessageInfo>();

        public MessageDao(IDatabase db)
        {
            this.db = db;
        }


        internal const string GetAllNewsSql = "select * from news,users where news.author=users.username";
        public List<Message> GetAllNews()
        {
            //   string sql = "select * from news,users where news.author=users.username";
            return db.ExecuteReader(GetAllNewsSql, this.LoadMessages);
        }

        internal List<Message> LoadMessages(IDataReader reader)
        {
            var newsList = new List<Message>();
            while (reader.Read())
            {
                var message = reader["content"] as string;
                var imageUrl = reader["ImageURL"] as string;
                var username = reader["author"] as string;
                var password = reader["password"] as string;
                var posttime = reader["posttime"] as string;
                var user = new User(username, password);
                var news = new Message(message, imageUrl, posttime, user);
                newsList.Add(news);
            }
            return newsList;
        }

        internal const string PublishMessageSql = "insert into news(content,imageURL,author,posttime) values(@CONTENT, @IMAGE_URL, @USER_NAME, @POST_TIME)";
        public void PublishMessage(Message message)
        { 
                    db.ExecuteNonQuery(PublishMessageSql,
                    db.CreateParameter("CONTENT", message.Content),
                    db.CreateParameter("IMAGE_URL", message.ImageUrl),
                    db.CreateParameter("USER_NAME", message.User.UserName),
                    db.CreateParameter("POST_TIME", message.PostTime));
       
        }

        public List<MessageInfo> updateMessageInfo(int clicktime)
        {
            newsList.Clear();
            newsList = GetAllNews();
            messageInfos.Clear();
            for (int i = newsList.Count - 1; i >= 0 && i >= newsList.Count - 3 * clicktime - 3; i--)
            {
                var messageInfo = new MessageInfo()
                {
                    Content = newsList[i].Content,
                    ImageUrl = newsList[i].ImageUrl,
                    Username = newsList[i].User.UserName,
                    PostTime = newsList[i].PostTime
                };
                messageInfos.Add(messageInfo);
            }

            return messageInfos;
        }
    }
}