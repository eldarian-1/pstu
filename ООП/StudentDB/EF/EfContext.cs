using Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class EfContext : DbContext, IOperations
    {
        private const string ConnectionString
            = "server=" + Const.Host
            + ";user=" + Const.User
            + ";password=" + Const.Password
            + ";database=" + Const.Database + ";";

        public EfContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString);
        }

        private DbSet<EfSubject> EfSubjects { get; set; }

        private DbSet<EfStudent> EfStudents { get; set; }

        private DbSet<EfMark> EfMarks { get; set; }

        public IEnumerable<Subject> Subjects => EfSubjects;

        public IEnumerable<Student> Students => EfStudents;

        public IEnumerable<Mark> Marks => EfMarks;

        public IEnumerable<MarkEntry> MarkEntries => throw new System.NotImplementedException();
    }
}
