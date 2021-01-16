using System.Collections.Generic;

namespace Entity
{
    public interface IDBContext
    {
        IEnumerable<Subject> Subjects { get; }
        IEnumerable<Student> Students { get; }
        IEnumerable<Mark> Marks { get; }
        IEnumerable<MarkEntry> MarkEntries { get; }
    }
}
