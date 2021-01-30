using Model.Entities;
using MySql.Data.MySqlClient;

namespace ADO.Writers
{
    class StudentRequester : EntityRequester<Student>
    {
        public StudentRequester(Student student) : base(student) { }

        protected override string Table => "";

        protected override string IdFieldName => "";

        protected override string InsertQuery => $"INSERT INTO {Const.StudentTable} (first_name, last_name) VALUES (@first_name, @last_name)";

        protected override string UpdateQuery => "";

        protected override string DeleteQuery => "";

        protected override Student ReadOne(MySqlDataReader reader)
        {
            Student student = new Student();
            student.StudentId = reader.GetInt64("student_id");
            student.FirstName = reader.GetString("first_name");
            student.LastName = reader.GetString("last_name");
            return student;
        }

        protected override void SetId(MySqlCommand command)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetData(MySqlCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
