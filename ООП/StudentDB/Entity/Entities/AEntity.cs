namespace Model.Entities
{
    public abstract class AEntity
    {
        public abstract void Insert(IOperateable operatorr);

        public abstract void Update(IOperateable operatorr);

        public abstract void Delete(IOperateable operatorr);
    }
}
