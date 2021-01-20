using System.Collections.Generic;

namespace Model.Entities
{
    public interface IEntity<TEntity>
        where TEntity : IEntity<TEntity>
    {
        IEnumerable<TEntity> SelectAll(IOperateable operation);

        TEntity SelectOne(IOperateable operation, int id);

        void Insert(IOperateable operation);

        void Update(IOperateable operation);

        void Delete(IOperateable operation);
    }
}
