using Model.Entities;

namespace Model
{
    public class DataAccessor
    {
        private IOperateable _Operation;

        public IOperateable Operation
        {
            get => _Operation;
            set
            {
                _Operation = value;
                Subjects = new Requester<Subject>(value);
                Students = new Requester<Student>(value);
                Marks = new Requester<Mark>(value);
            }
        }

        public IQueryable<Subject> Subjects { get; private set; }

        public IQueryable<Student> Students { get; private set; }

        public IQueryable<Mark> Marks { get; private set; }
    }
}
