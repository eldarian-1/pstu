using Entity;
using System.Collections.Generic;

namespace ADO
{
    public class AdoContext : IDBContext
    {
        private const string ConnectionString
            = "Database=" + Const.Database
            + ";Datasource=" + Const.Host
            + ";User=" + Const.User
            + ";Password=" + Const.Password;

        public AdoContext() { }

        public IEnumerable<Subject> Subjects
        {
            get
            {
                return null;
            }
        }

        public IEnumerable<Student> Students
        {
            get
            {
                return null;
            }
        }

        public IEnumerable<Mark> Marks
        {
            get
            {
                return null;
            }
        }

        public IEnumerable<MarkEntry> MarkEntries
        {
            get
            {
                return null;
            }
        }
    }
}
