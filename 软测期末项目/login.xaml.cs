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
    /// login.xaml 的交互逻辑
    /// </summary>
    public partial class login : Window
    {
        private User user;
        private IUserDao userDao;
        private string username;
        private string userpassword;
        private IDatabase db = new Database();
        public login()
        {
            userDao= new UserDao(db);
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

        private void openregisterwindow(object sender, RoutedEventArgs e)
        {
            Register registerwindow = new Register();
            registerwindow.Show();
            Close();
        }

        public bool doLoginUser(string username, string password)
        {
           
            user = new User(username, password);
            if (userDao.CheckLogin(user))
            {
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                Close();
                return true;
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                return false;
            }
        }

        private void loginuser(object sender, RoutedEventArgs e)
        {
            this.username = UsernameBox.Text;
            this.userpassword = PwdBox.Password;
            if (username == "" || userpassword == "")
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (doLoginUser(username, userpassword))
            {
                MessageBox.Show("登录成功");
            }

        }
    }
}
