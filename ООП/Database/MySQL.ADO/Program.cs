using System;
using MySql.Data.MySqlClient;

namespace MySQL.ADO
{
    internal class Program
    {
        private static string host = "localhost"; // Имя хоста
        private static string database = "testdb"; // Имя базы данных
        private static string user = "root"; // Имя пользователя
        private static string password = "password"; // Пароль пользователя

        private static string ConnectionString // Строка подключения
            => "Database=" + database
            + ";Datasource=" + host
            + ";User=" + user
            + ";Password=" + password;

        public static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM users;";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("id {0}: {1}", reader.GetInt64(0), reader.GetString(1));
            connection.Close();
            Console.ReadKey();
        }
    }
}
