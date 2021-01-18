namespace Model.Entities
{
    public class Mark : AEntity
    {
        public virtual long MarkId { get; set; }

        public virtual long StudentId { get; set; }

        public virtual long SubjectId { get; set; }

        public virtual byte Value { get; set; }

        public sealed override void Insert(IOperateable operatorr)
        {
            operatorr.InsertMark(this);
        }

        public sealed override void Update(IOperateable operatorr)
        {
            operatorr.UpdateMark(this);
        }

        public sealed override void Delete(IOperateable operatorr)
        {
            operatorr.DeleteMark(this);
        }
    }
}
