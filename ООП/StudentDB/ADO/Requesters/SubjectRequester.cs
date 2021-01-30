using Model.Entities;
using MySql.Data.MySqlClient;

namespace ADO.Requesters
{
    internal class SubjectRequester : EntityRequester<Subject>
    {
        public SubjectRequester() : base() { }

        public SubjectRequester(long id) : base(id) { }

        public SubjectRequester(Subject subject) : base(subject) { }

        protected override string Table => Const.SubjectTable;

        protected override string IdFieldName => "subject_id";

        protected override string InsertQuery => $"INSERT INTO {Table} (subject_name) VALUES (@subject_name)";

        protected override string UpdateQuery => $"UPDATE {Table} SET subject_name=@subject_name WHERE {IdFieldName}={Id}";

        protected override Subject ReadOne(MySqlDataReader reader)
        {
            Subject subject = new Subject();
            subject.SubjectId = reader.GetInt64(IdFieldName);
            subject.SubjectName = reader.GetString("subject_name");
            return subject;
        }

        protected override void SetId(MySqlCommand command)
        {
            MySqlParameter idParam = new MySqlParameter($"@{IdFieldName}", Entity.SubjectId);
            command.Parameters.Add(idParam);
        }

        protected override void SetData(MySqlCommand command)
        {
            MySqlParameter nameParam = new MySqlParameter("@subject_name", Entity.SubjectName);
            command.Parameters.Add(nameParam);
        }
    }
}
