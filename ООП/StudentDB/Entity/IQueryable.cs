using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    public interface IQueryable<TEntity>
        where TEntity : IEntity<TEntity>
    {
        IEnumerable<TEntity> SelectAll(TEntity entity);

        TEntity SelectOne(TEntity entity, int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
