using Entity;
using System.Collections.Generic;

namespace EF
{
    public abstract class AProxyContext : IDBContext
    {
        private IDBContext m_Context;

        public AProxyContext(IDBContext context)
        {
            m_Context = context;
        }

        public IEnumerable<Subject> Subjects => m_Context.Subjects;

        public IEnumerable<Student> Students => m_Context.Students;

        public IEnumerable<Mark> Marks => m_Context.Marks;

        public IEnumerable<MarkEntry> MarkEntries => m_Context.MarkEntries;
    }
}
