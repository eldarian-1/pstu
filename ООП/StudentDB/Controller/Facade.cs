using EF;
using ADO;
using Mock;
using Model;
using Model.Entities;
using System.Collections.Generic;

namespace Controller
{
    public class Facade
    {
        private DataAccessor _Accessor;
        private IOperateable _Current;
        private IDictionary<string, IOperateable> _Operations;

        public Facade()
        {
            _Accessor = new DataAccessor();
            _Current = new MockOperation();
            _Accessor.Current = _Current;
            _Operations = new Dictionary<string, IOperateable>();
            _Operations.Add("MockOperation", _Current);
        }

        public void SetOperation(string key)
        {
            _Current = _Operations[key];
        }

        public IQueryable<Student> Students => _Accessor.Students;

        public IQueryable<Subject> Subjects => _Accessor.Subjects;

        public IQueryable<MarkEntry> Marks => _Accessor.Marks;
    }
}
