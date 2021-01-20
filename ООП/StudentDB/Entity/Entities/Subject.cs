using System.Collections.Generic;

namespace Model.Entities
{
    public class Subject : IEntity<Subject>
    {
        public virtual long SubjectId { get; set; }

        public virtual string Name { get; set; }

        public IEnumerable<Subject> SelectAll(IOperateable operation)
        {
            return operation.SelectSubjects();
        }

        public Subject SelectOne(IOperateable operation, int id)
        {
            return operation.SelectOneSubject(id);
        }

        public void Insert(IOperateable operatorr)
        {
            operatorr.InsertSubject(this);
        }

        public void Update(IOperateable operatorr)
        {
            operatorr.UpdateSubject(this);
        }

        public void Delete(IOperateable operatorr)
        {
            operatorr.DeleteSubject(this);
        }
    }
}
