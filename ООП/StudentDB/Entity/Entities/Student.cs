using System.Collections.Generic;

namespace Model.Entities
{
    public class Student : IEntity<Student>
    {
        public virtual long StudentId { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public IEnumerable<Student> SelectAll(IOperateable operation)
        {
            return operation.SelectStudents();
        }

        public Student SelectOne(IOperateable operation, int id)
        {
            return operation.SelectOneStudent(id);
        }

        public void Insert(IOperateable operation)
        {
            operation.InsertStudent(this);
        }

        public void Update(IOperateable operation)
        {
            operation.UpdateStudent(this);
        }

        public void Delete(IOperateable operation)
        {
            operation.DeleteStudent(this);
        }
    }
}
