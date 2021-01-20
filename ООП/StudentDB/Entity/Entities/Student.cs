using System.Collections.Generic;

namespace Model.Entities
{
    public class Student : AEntity
    {
        public virtual long StudentId { get; }

        public virtual string FirstName { get; }

        public virtual string LastName { get; }

        public sealed override IEnumerable<AEntity> SelectAll(IOperateable operation)
        {
            return operation.SelectStudents();
        }

        public sealed override AEntity SelectOne(IOperateable operation, int id)
        {
            return operation.SelectOneStudent(id);
        }

        public sealed override void Insert(IOperateable operation)
        {
            operation.InsertStudent(this);
        }

        public sealed override void Update(IOperateable operation)
        {
            operation.UpdateStudent(this);
        }

        public sealed override void Delete(IOperateable operation)
        {
            operation.DeleteStudent(this);
        }
    }
}
