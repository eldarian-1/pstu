namespace Model.Entities
{
    public class Subject : AEntity
    {
        public virtual long SubjectId { get; }

        public virtual string Name { get; }

        public sealed override void Insert(IOperateable operatorr)
        {
            operatorr.InsertSubject(this);
        }

        public sealed override void Update(IOperateable operatorr)
        {
            operatorr.UpdateSubject(this);
        }

        public sealed override void Delete(IOperateable operatorr)
        {
            operatorr.DeleteSubject(this);
        }
    }
}
