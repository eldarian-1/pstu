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
        private string _Key;
        private IOperateable _Current;
        private IDictionary<string, IOperateable> _Operations;

        public Facade()
        {
            _Accessor = new DataAccessor();
            _Key = "Mock Operation";
            _Current = new MockOperation();
            _Accessor.Operation = _Current;
            _Operations = new Dictionary<string, IOperateable>();
            _Operations.Add(_Key, _Current);
            _Operations.Add("Entity Framework", new EfProxyOperation());
            _Operations.Add("ADO.NET", new AdoOperation());
        }

        public string Key => _Key;

        public IEnumerable<string> GetOperations()
        {
            return _Operations.Keys;
        }

        public void SetOperation(string key)
        {
            _Key = key;
            _Current = _Operations[key];
            _Accessor.Operation = _Current;
        }

        public IQueryable<Student> Students => _Accessor.Students;

        public IQueryable<Subject> Subjects => _Accessor.Subjects;

        public IQueryable<Mark> Marks => _Accessor.Marks;
    }
}
