using Model.Entities;

namespace Model
{
    public abstract class AContext
    {
        public AContext(IOperateable operatorr)
        {
            Subjects = new DBCollection<Subject>(operatorr);
            Students = new DBCollection<Student>(operatorr);
            Marks = new DBCollection<MarkEntry>(operatorr);
        }

        public DBCollection<Subject> Subjects { get; }

        public DBCollection<Student> Students { get; }

        public DBCollection<MarkEntry> Marks { get; }
    }
}
