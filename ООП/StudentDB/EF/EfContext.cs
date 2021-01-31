using EF.Entities;
using System.Data.Common;
using System.Data.Entity;

namespace EF
{
    internal class EfContext : DbContext
    {
        public EfContext() : base("dataContext")
        {
            Configure();
        }

        public EfContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<EfSubject> Subjects { get; set; }

        public DbSet<EfStudent> Students { get; set; }

        public DbSet<EfMark> Marks { get; set; }
    }
}
