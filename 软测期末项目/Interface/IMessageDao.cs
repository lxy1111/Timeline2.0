using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeline.entity;

namespace Timeline.Interface
{
    public interface IMessageDao
    {
        List<Message> GetAllNews();
        void PublishMessage(Message message);
        List<MessageInfo> updateMessageInfo(int clicktime);
    }
}
