using System.Collections.Generic;

namespace Model
{
    public interface IQueryable<TEntity>
        where TEntity : AEntity<TEntity>
    {
        IEnumerable<TEntity> SelectAll();

        TEntity SelectOne(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
