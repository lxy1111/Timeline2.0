using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Castle.Components.DictionaryAdapter.Xml;
using MySql.Data.MySqlClient;
using Timeline.entity;
using Timeline.Interface;
using Timeline.server;


namespace Timeline.server
{
    public class UserDao : IUserDao
    {
        private IDatabase db;

        public UserDao(IDatabase db)
        {
            this.db = db;
        }
        
        internal const string CheckRegisterSql = "select * from users where username=@USER_NAME";

        public bool CheckRegister(User user)
        {
            return db.ExecuteScalar(CheckRegisterSql, db.CreateParameter("USER_NAME", user.UserName)) != null;
        }


        internal const string CheckLoginSql = "select * from users where username=@USER_NAME and password=@PASSWORD";
        public bool CheckLogin(User user)
        {
          //  var sql = "select * from users where username=@USER_NAME and password=@PASSWORD";
            return db.ExecuteScalar(CheckLoginSql, db.CreateParameter("USER_NAME", user.UserName),
                       db.CreateParameter("PASSWORD", user.UserPassword) ) != null;
        }
        internal const string RegisterUserSql = "insert into users values (@USER_NAME,@PASSWORD)";
        public void RegisterUser(User user)
        {
          //  var sql = "insert into users values(@USER_NAME, @PASSWORD)";
            db.ExecuteNonQuery(RegisterUserSql, db.CreateParameter("USER_NAME", user.UserName),
                db.CreateParameter("PASSWORD", user.UserPassword)); 
        }
    }
}