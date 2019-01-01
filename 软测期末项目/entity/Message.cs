using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeline.Interface;

namespace Timeline.entity
{
   
    public class Message
    {
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string PostTime { get; set; }
        public User User { get; set; }

        public Message(string content, string ImageURL,string postTime,User user)
        {
            Content = content;
            ImageUrl = ImageURL;
            PostTime = postTime;
            User = user;
        }
    }
}
