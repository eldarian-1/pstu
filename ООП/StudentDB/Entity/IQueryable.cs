using Model.Entities;
using System.Collections.Generic;

namespace Model
{
    interface IQueryable
    {
        IEnumerable<AEntity> SelectAll(AEntity entity);

        AEntity SelectOne(AEntity entity, int id);

        void Insert(AEntity entity);

        void Update(AEntity entity);

        void Delete(AEntity entity);
    }
}
