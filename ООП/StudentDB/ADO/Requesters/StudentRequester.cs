using Model.Entities;
using MySql.Data.MySqlClient;

namespace ADO.Requesters
{
    class StudentRequester : EntityRequester<Student>
    {
        public StudentRequester() : base() { }

        public StudentRequester(long id) : base(id) { }

        public StudentRequester(Student student) : base(student) { }

        protected override string Table => Const.StudentTable;

        protected override string IdFieldName => "student_id";

        protected override string InsertQuery => $"INSERT INTO {Table} (first_name, last_name) VALUES (@first_name, @last_name)";

        protected override string UpdateQuery => $"UPDATE {Table} SET first_name=@first_name, last_name=@last_name WHERE {IdFieldName}={Id}";

        protected override Student ReadOne(MySqlDataReader reader)
        {
            Student student = new Student();
            student.StudentId = reader.GetInt64(IdFieldName);
            student.FirstName = reader.GetString("first_name");
            student.LastName = reader.GetString("last_name");
            return student;
        }

        protected override void SetId(MySqlCommand command)
        {
            MySqlParameter idParam = new MySqlParameter($"@{IdFieldName}", Entity.StudentId);
            command.Parameters.Add(idParam);
        }

        protected override void SetData(MySqlCommand command)
        {
            MySqlParameter firstNameParam = new MySqlParameter("@first_name", Entity.FirstName);
            MySqlParameter lastNameParam = new MySqlParameter("@last_name", Entity.LastName);
            command.Parameters.Add(firstNameParam);
            command.Parameters.Add(lastNameParam);
        }
    }
}
