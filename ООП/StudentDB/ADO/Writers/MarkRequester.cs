using Model.Entities;
using MySql.Data.MySqlClient;

namespace ADO.Writers
{
    class MarkRequester : EntityRequester<Mark>
    {
        public MarkRequester(Mark mark) : base(mark) { }

        protected override string Table => "";

        protected override string IdFieldName => "";

        protected override string InsertQuery => $"INSERT INTO {Const.MarkTable} (subject_id, student_id, value) VALUES (@subject_id, @student_id, @value)";

        protected override string UpdateQuery => "";

        protected override string DeleteQuery => "";

        protected override Mark ReadOne(MySqlDataReader reader)
        {
            Mark mark = new Mark();
            mark.MarkId = reader.GetInt64("mark_id");
            mark.SubjectId = reader.GetInt64("subject_id");
            mark.StudentId = reader.GetInt64("student_id");
            mark.Value = reader.GetByte("value");
            return mark;
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
