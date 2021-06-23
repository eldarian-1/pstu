using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MySQL.ADO.CRUD
{
    internal class DataRequester
    {
        private static string host = "localhost"; // Имя хоста
        private static string database = "testdb"; // Имя базы данных
        private static string user = "root"; // Имя пользователя
        private static string password = "19841986"; // Пароль пользователя

        private static string ConnectionString // Строка подключения
            => "Database=" + database
            + ";Datasource=" + host
            + ";User=" + user
            + ";Password=" + password;

        public ICollection<User> SelectAll()
        {
            ICollection<User> result = new HashSet<User>();
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM users;";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                result.Add(new User { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            connection.Close();
            return result;
        }

        public User SelectOne(int id)
        {
            User result = null;
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM users WHERE user_id={id};";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                result = new User { Id = reader.GetInt32(0), Name = reader.GetString(1) };
            connection.Close();
            return result;
        }

        public void Insert(User user)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO users (user_name) VALUES (\"{user.Name}\");";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(User user)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE users SET user_name=\"{user.Name}\" WHERE user_id={user.Id};";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(User user)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM users WHERE user_id={user.Id};";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
