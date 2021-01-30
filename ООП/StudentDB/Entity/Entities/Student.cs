using System.Collections.Generic;

namespace Model.Entities
{
    public class Student : AEntity<Student>
    {
        public virtual long StudentId { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        internal override IEnumerable<Student> SelectAll(IOperateable operation)
        {
            return operation.SelectStudents();
        }

        internal override Student SelectOne(IOperateable operation, int id)
        {
            return operation.SelectOneStudent(TODO);
        }

        internal override void Insert(IOperateable operation)
        {
            operation.InsertStudent(this);
        }

        internal override void Update(IOperateable operation)
        {
            operation.UpdateStudent(this);
        }

        internal override void Delete(IOperateable operation)
        {
            operation.DeleteStudent(this);
        }
    }
}
