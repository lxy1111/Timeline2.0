using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Timeline.entity;
using Timeline.Interface;
using Timeline.server;
using Timeline.server;

namespace Timeline
{
    /// <summary>
    /// PublishMessage.xaml 的交互逻辑
    /// </summary>
    public partial class PublishMessage : Window
    {
        private User user;
        private IUserDao userDao;
        private IMessageDao messageDao;
        private Message news;
        private string Imageurl;
        private string rootURL="";
        private IDatabase db=new Database();


        public PublishMessage(User user)
        {
            this.user = user;
            userDao=new UserDao(db);
            messageDao=new MessageDao(db);
            InitializeComponent();
        }

        private void publishMessage(object sender, RoutedEventArgs e)
        {
            string message = this.message.Text;
            Imageurl = ImageURL.Text.Replace("\\","\\\\");
            if (message == ""&&Imageurl=="")
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            
            DateTime now = DateTime.Now;
            string nowtime = now.GetDateTimeFormats('f')[0].ToString();
            news =new Message(message,Imageurl,nowtime,user);
            messageDao.PublishMessage(news);
            MessageBox.Show("发布成功！");
            Close();
        }

        private void choosePath(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofld = new System.Windows.Forms.OpenFileDialog();
            if (ofld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               this.ImageURL.Text= ofld.FileName;
               
            }
        }
    }
}
