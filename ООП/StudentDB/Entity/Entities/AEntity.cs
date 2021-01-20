using System.Collections.Generic;

namespace Model.Entities
{
    public abstract class AEntity
    {
        public abstract IEnumerable<AEntity> SelectAll(IOperateable operation);

        public abstract AEntity SelectOne(IOperateable operation, int id);

        public abstract void Insert(IOperateable operation);

        public abstract void Update(IOperateable operation);

        public abstract void Delete(IOperateable operation);
    }
}
