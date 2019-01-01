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

namespace Timeline
{
    /// <summary>
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {

        private User user;
        private string username;
        private string userpassword;
        private IUserDao userDao;
        private IDatabase db=new Database();

        public Register()
        {
            
            userDao=new UserDao(db);
         
            InitializeComponent();
        }
        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void user_gotfocus(object sender, RoutedEventArgs e)
        {
            UsernameBlock.Visibility = Visibility.Collapsed;
        }
        private void user_losefocus(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text == "")
                UsernameBlock.Visibility = Visibility.Visible;
        }
        private void pwd_gotfocus(object sender, RoutedEventArgs e)
        {
            PwdBlock.Visibility = Visibility.Collapsed;
        }
        private void pwd_losefocus(object sender, RoutedEventArgs e)
        {
            if (PwdBox.Password == "")
                PwdBlock.Visibility = Visibility.Visible;
        }

        public void register(object sender, RoutedEventArgs e)
        {
            this.username = UsernameBox.Text;
            this.userpassword = PwdBox.Password;
            if (username == "" || userpassword == "")
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            user = new User(username, userpassword);
            if (userDao.CheckRegister(user))
            {
                MessageBox.Show("该用户已存在");
                return;
            }
            userDao.RegisterUser(user);
            MessageBox.Show("注册成功！");
        }

        private void returntologin(object sender, RoutedEventArgs e)
        {
            login loginwindow=new login();
            loginwindow.Show();
            Close();
        }
    }
}
