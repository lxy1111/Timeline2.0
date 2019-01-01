using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Timeline.entity;
using Timeline.Interface;
using Timeline.server;

namespace 软测期末项目.server
{
    public class MessageDao : IMessageDao
    {
        private IDatabase db;

        public MessageDao(IDatabase db)
        {
            this.db = db;
        }

        public List<Message> GetAllNews()
        {
            string sql = "select * from news,users where news.author=users.username";
            return db.ExecuteReader(sql, rs =>
            {
                var newsList = new List<Message>();
                while (rs.Read())
                {
                    var message = rs["content"] as string;
                    var imageUrl = rs["ImageURL"] as string;
                    var username = rs["author"] as string;
                    var password = rs["password"] as string;
                    var posttime = rs["posttime"] as string;
                    var user = new User(username, password);
                    var news = new Message(message, imageUrl, posttime, user);
                    newsList.Add(news);
                }

                return newsList;
            });
        }

        public bool PublishMessage(Message message)
        {
            var sql =
                "insert into news(content,imageURL,author,posttime) values(@CONTENT, @IMAGE_URL, @USER_NAME, @POST_TIME)";
            try
            {
                    db.ExecuteNonQuery(sql,
                    db.CreateParameter("CONTENT", message.Content),
                    db.CreateParameter("IMAGE_URL", message.ImageUrl),
                    db.CreateParameter("USER_NAME", message.User?.UserName),
                    db.CreateParameter("POST_TIME", message.PostTime));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}