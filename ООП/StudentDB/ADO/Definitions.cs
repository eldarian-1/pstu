using MySql.Data.MySqlClient;

namespace ADO
{
    internal delegate void SetQueryData<TEntity>(MySqlCommand command);

    internal static class Const
    {
        public const string Host = "localhost";
        public const string User = "root";
        public const string Password = "19841986";
        public const string Database = "mark_journal";

        public const string SubjectTable = "subjects";
        public const string StudentTable = "students";
        public const string MarkTable = "marks";

        public const string ConnectionString
            = "Database=" + Database
            + ";Datasource=" + Host
            + ";User=" + User
            + ";Password=" + Password;
    }
}
