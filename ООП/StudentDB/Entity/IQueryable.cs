using Model.Entities;

namespace Model
{
    interface IQueryable
    {
        void Restart();

        void Insert(AEntity entity);

        void Update(AEntity entity);

        void Delete(AEntity entity);
    }
}
