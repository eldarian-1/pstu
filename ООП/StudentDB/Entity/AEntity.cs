using System.Collections.Generic;

namespace Model
{
    public abstract class AEntity<TEntity>
        where TEntity : AEntity<TEntity>
    {
        internal abstract IEnumerable<TEntity> SelectAll(IOperateable operation);

        internal abstract TEntity SelectOne(IOperateable operation, int id);

        internal abstract void Insert(IOperateable operation);

        internal abstract void Update(IOperateable operation);

        internal abstract void Delete(IOperateable operation);
    }
}
