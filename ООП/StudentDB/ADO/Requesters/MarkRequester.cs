using Model.Entities;
using MySql.Data.MySqlClient;

namespace ADO.Requesters
{
    class MarkRequester : EntityRequester<Mark>
    {
        public MarkRequester() : base() { }

        public MarkRequester(long id) : base(id) { }

        public MarkRequester(Mark mark) : base(mark) { }

        protected override string Table => Const.MarkTable;

        protected override string IdFieldName => "mark_id";

        protected override string InsertQuery => $"INSERT INTO {Table} (subject_id, student_id, mark_value) VALUES (@subject_id, @student_id, @mark_value)";

        protected override string UpdateQuery => $"UPDATE {Table} SET subject_id=@subject_id, student_id=@student_id, mark_value=@mark_value WHERE {IdFieldName}={Id}";

        protected override Mark ReadOne(MySqlDataReader reader)
        {
            Mark mark = new Mark();
            mark.MarkId = reader.GetInt64(IdFieldName);
            mark.SubjectId = reader.GetInt64("subject_id");
            mark.StudentId = reader.GetInt64("student_id");
            mark.MarkValue = reader.GetByte("mark_value");
            return mark;
        }

        protected override void SetId(MySqlCommand command)
        {
            MySqlParameter idParam = new MySqlParameter($"@{IdFieldName}", Entity.MarkId);
            command.Parameters.Add(idParam);
        }

        protected override void SetData(MySqlCommand command)
        {
            MySqlParameter subjectIdParam = new MySqlParameter("@subject_id", Entity.SubjectId);
            MySqlParameter studentIdParam = new MySqlParameter("@student_id", Entity.StudentId);
            MySqlParameter valueParam = new MySqlParameter("@mark_value", Entity.MarkValue);
            command.Parameters.Add(subjectIdParam);
            command.Parameters.Add(studentIdParam);
            command.Parameters.Add(valueParam);
        }
    }
}
