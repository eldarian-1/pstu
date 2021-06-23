using EF.Entities;
using Model;
using System.Data.Entity;

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

        public static TChild Update<TParent, TChild>(this DbSet<TChild> entities, TChild item)
            where TChild : class, IEntity<TParent, TChild>
            where TParent : AEntity<TParent>
        {
            return entities.Find(item.Identificator()).Update(item);
        }
    }
}
