using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    internal class EfContext : DbContext
    {
        public EfContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<EfSubject> Subjects { get; set; }

        public DbSet<EfStudent> Students { get; set; }

        public DbSet<EfMark> Marks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Const.ConnectionString);
        }
    }
}
