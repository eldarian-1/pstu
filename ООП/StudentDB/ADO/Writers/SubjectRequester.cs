using Model.Entities;
using MySql.Data.MySqlClient;

namespace ADO.Writers
{
    internal class SubjectRequester : EntityRequester<Subject>
    {
        public SubjectRequester(Subject subject) : base(subject) { }

        protected override string Table => "";

        protected override string IdFieldName => "";

        protected override string InsertQuery => $"INSERT INTO {Const.SubjectTable} (name) VALUES (@name)";

        protected override string UpdateQuery => "";

        protected override string DeleteQuery => "";

        protected override Subject ReadOne(MySqlDataReader reader)
        {
            Subject subject = new Subject();
            subject.SubjectId = reader.GetInt64("subject_id");
            subject.Name = reader.GetString("name");
            return subject;
        }

        protected override void SetId(MySqlCommand command)
        {
            MySqlParameter idParam = new MySqlParameter("@subject_id", Entity.SubjectId);
            command.Parameters.Add(idParam);
        }

        protected override void SetData(MySqlCommand command)
        {
            MySqlParameter nameParam = new MySqlParameter("@name", Entity.Name);
            command.Parameters.Add(nameParam);
        }
    }
}
