using Model;
using Model.Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ADO
{
    internal class EntityReader
    {
        public Subject ReadSubject(MySqlDataReader reader)
        {
            Subject subject = new Subject();
            subject.SubjectId = reader.GetInt64("subject_id");
            subject.Name = reader.GetString("name");
            return subject;
        }

        public Student ReadStudent(MySqlDataReader reader)
        {
            Student student = new Student();
            student.StudentId = reader.GetInt64("student_id");
            student.FirstName = reader.GetString("first_name");
            student.LastName = reader.GetString("last_name");
            return student;
        }

        public Mark ReadMark(MySqlDataReader reader)
        {
            Mark mark = new Mark();
            mark.MarkId = reader.GetInt64("mark_id");
            mark.SubjectId = reader.GetInt64("subject_id");
            mark.StudentId = reader.GetInt64("student_id");
            mark.Value = reader.GetByte("value");
            return mark;
        }

        public TEntity SelectOne<TEntity>(string nameTable, string fieldId, ReadEntity<TEntity> reader)
            where TEntity : AEntity<TEntity>
        {
            TEntity result = null;
            using (MySqlConnection connection = new MySqlConnection(Const.ConnectionString))
            {
                string query = $"SELECT * FROM {nameTable} WHERE {fieldId}";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader res = command.ExecuteReader();
                while (res.Read())
                    result = reader(res);
            }
            return result;
        }

        public IEnumerable<TEntity> SelectAll<TEntity>(string nameTable, ReadEntity<TEntity> reader)
            where TEntity : AEntity<TEntity>
        {
            using (MySqlConnection connection = new MySqlConnection(Const.ConnectionString))
            {
                string query = $"SELECT * FROM {nameTable}";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader result = command.ExecuteReader();
                while (result.Read())
                    yield return reader(result);
            }
        }
    }
}
