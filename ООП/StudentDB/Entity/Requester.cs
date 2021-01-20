using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    public class Requester<TEntity> : IQueryable<TEntity>
        where TEntity : IEntity<TEntity>
    {
        private IOperateable _Operation;

        public Requester(IOperateable operation)
        {
            _Operation = operation;
        }

        public IEnumerable<TEntity> SelectAll(TEntity entity)
        {
            return entity.SelectAll(_Operation);
        }

        public TEntity SelectOne(TEntity entity, int id)
        {
            return entity.SelectOne(_Operation, id);
        }

        public void Insert(TEntity entity)
        {
            entity.Insert(_Operation);
        }

        public void Update(TEntity entity)
        {
            entity.Update(_Operation);
        }

        public void Delete(TEntity entity)
        {
            entity.Delete(_Operation);
        }
    }
}
