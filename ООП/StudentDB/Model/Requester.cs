using System.Collections.Generic;

namespace Model
{
    internal class Requester<TEntity> : IQueryable<TEntity>
        where TEntity : AEntity<TEntity>, new()
    {
        private IOperateable _Operation;

        internal Requester(IOperateable operation)
        {
            _Operation = operation;
        }

        public IEnumerable<TEntity> SelectAll()
        {
            return new TEntity().SelectAll(_Operation);
        }

        public TEntity SelectOne(int id)
        {
            return new TEntity().SelectOne(_Operation, id);
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
