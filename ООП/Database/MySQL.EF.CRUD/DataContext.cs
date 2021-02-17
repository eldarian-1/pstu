using System.Data.Common;
using System.Data.Entity;

namespace MySQL.EF.CRUD
{
    internal class DataContext : DbContext
    {
        public DataContext() : base("DataConnection")
        {
            Configure();
        }

        public DataContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        public DbSet<User> Users { get; set; }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
    }
}
