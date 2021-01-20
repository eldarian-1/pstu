using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    public class DBCollection<TEntity>
        : List<TEntity>, IQueryable
        where TEntity : AEntity
    {
        private IOperateable _Operation;

        public DBCollection(IOperateable operation)
        {
            _Operation = operation;
        }

        public IEnumerable<AEntity> SelectAll(AEntity entity)
        {
            return entity.SelectAll(_Operation);
        }

        public AEntity SelectOne(AEntity entity, int id)
        {
            return entity.SelectOne(_Operation, id);
        }

        public void Insert(AEntity entity)
        {
            entity.Insert(_Operation);
        }

        public void Update(AEntity entity)
        {
            entity.Update(_Operation);
        }

        public void Delete(AEntity entity)
        {
            entity.Delete(_Operation);
        }
    }
}
