using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    public class DBCollection<TEntity>
        : List<TEntity>, IQueryable
        where TEntity : AEntity
    {
        private IOperateable _Operator;

        public DBCollection(IOperateable operatorr)
        {
            _Operator = operatorr;
            Initialize();
        }

        protected void Initialize()
        {
            _Operator.FillData(this as List<AEntity>);
        }

        public void Restart()
        {
            Clear();
            Initialize();
        }

        public void Insert(AEntity entity)
        {
            entity.Insert(_Operator);
        }

        public void Update(AEntity entity)
        {
            entity.Update(_Operator);
        }

        public void Delete(AEntity entity)
        {
            entity.Delete(_Operator);
        }
    }
}
