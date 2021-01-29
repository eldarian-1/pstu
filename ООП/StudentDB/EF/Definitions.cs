namespace EF
{
    internal static class Const
    {
        public const string Host = "localhost";
        public const string User = "root";
        public const string Password = "19841986";
        public const string Database = "mark_journal";

        public const string ConnectionString
            = "server=" + Host
            + ";user=" + User
            + ";password=" + Password
            + ";database=" + Database + ";";
    }
}
