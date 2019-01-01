using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Timeline.server
{
    public interface IDatabase
    {
        IDataParameter CreateParameter(string name, object value);
        T ExecuteReader<T>(string sql, Func<IDataReader, T> func, params IDataParameter[] parameters);
        object ExecuteScalar(string sql, params IDataParameter[] parameters);
        int ExecuteNonQuery(string sql, params IDataParameter[] parameters);
    }
    
    class Database : IDatabase
    {
        private const string ConnectionString = "server=localhost;port=3306;User Id=root;password=123456;Database=timeline;charset=utf8";

        public IDataParameter CreateParameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }

        public T ExecuteReader<T>(string sql, Func<IDataReader, T> func, params IDataParameter[] parameters)
        {
            return Execute(sql, parameters, command =>
            {
                using (var reader = command.ExecuteReader())
                {
                    return func(reader);
                }
            });
        }

        public object ExecuteScalar(string sql, params IDataParameter[] parameters)
        {
            return Execute(sql, parameters, command => command.ExecuteScalar());
        }

        public int ExecuteNonQuery(string sql, params IDataParameter[] parameters)
        {
            return Execute(sql, parameters, command => command.ExecuteNonQuery());
        }

        private static T Execute<T>(string sql, IDataParameter[] parameters, Func<MySqlCommand, T> func)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter as MySqlParameter);
                    }
                }

                return func(command);
            }
        }
    }
}
