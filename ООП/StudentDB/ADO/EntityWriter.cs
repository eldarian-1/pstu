using Model.Entities;
using MySql.Data.MySqlClient;

namespace ADO
{
    internal class EntityWriter
    {
        public MySqlCommand WriteSubject(bool isInsert, MySqlConnection connection, Subject subject)
        {
            string query = "";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            if (!isInsert)
            {
                MySqlParameter idParam = new MySqlParameter("@subject_id", subject.Name);
                command.Parameters.Add(idParam);
            }
            MySqlParameter nameParam = new MySqlParameter("@name", subject.Name);
            command.Parameters.Add(nameParam);
            return command;
        }

        public void WriteStudent(MySqlCommand command, Student student)
        {

        }

        public void WriteMark(MySqlCommand command, Mark mark)
        {

        }

        public void Insert<TEntity>(string query, TEntity entity, WriteEntity<TEntity> writer)
        {
            using (MySqlConnection connection = new MySqlConnection(Const.ConnectionString))
                writer(true, connection, entity).ExecuteNonQuery();
        }
    }
}
