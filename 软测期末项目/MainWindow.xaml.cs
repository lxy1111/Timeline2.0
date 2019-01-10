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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Timeline.entity;
using Timeline.Interface;
using Timeline.server;
using 软测期末项目;
using Timeline.entity;
using Timeline.server;

namespace Timeline
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;
        private List<Message> newsList=new List<Message>();
        private IUserDao userDao;
        private IMessageDao messageDao;
        private static List<MessageInfo> messageInfos = new List<MessageInfo>();
        private int clicktime;
        private IDatabase db = new Database();

        public MainWindow(User user)
        {
            clicktime = 0;
            InitializeComponent();
            this.user = user;
            userDao = new UserDao(db);
            messageDao=new MessageDao(db);
            newsDataBinding();
        
        }

        public static List<MessageInfo> GetMessageInfoList()
        {
            return messageInfos;
        }

  

        public void newsDataBinding()
        {
            messageInfos = messageDao.updateMessageInfo(clicktime);
            NewsLists.ItemsSource = messageInfos;
          
        }

        private void openPublishMessageWindow(object sender, RoutedEventArgs e)
        {
             PublishMessage publishWindow=new PublishMessage(user);
             publishWindow.Show();
          
        }

   

        private void update(object sender, RoutedEventArgs e)
        {
            NewsLists.ItemsSource = null;
            newsDataBinding();
        }

        private void showMore(object sender, RoutedEventArgs e)
        {
            clicktime++;
            NewsLists.ItemsSource = null;
            newsDataBinding();
        }

        private void NewsLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
