using MySql.Data.MySqlClient;

namespace ADO
{
    internal delegate TEntity ReadEntity<TEntity>(MySqlDataReader reader);

    internal delegate MySqlCommand WriteEntity<TEntity>(bool isInsert, MySqlConnection connection, TEntity entity);

    internal static class Const
    {
        public const string Host = "localhost";
        public const string User = "root";
        public const string Password = "19841986";
        public const string Database = "mark_journal";

        public const string ConnectionString
            = "Database=" + Database
            + ";Datasource=" + Host
            + ";User=" + User
            + ";Password=" + Password;
    }
}
