namespace Model.Entities
{
    public class Student : AEntity
    {
        public virtual long StudentId { get; }

        public virtual string FirstName { get; }

        public virtual string LastName { get; }

        public sealed override void Insert(IOperateable operatorr)
        {
            operatorr.InsertStudent(this);
        }

        public sealed override void Update(IOperateable operatorr)
        {
            operatorr.UpdateStudent(this);
        }

        public sealed override void Delete(IOperateable operatorr)
        {
            operatorr.DeleteStudent(this);
        }
    }
}
