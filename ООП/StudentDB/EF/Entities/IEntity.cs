using Model;

namespace EF.Entities
{
    public interface IEntity<TParent, TChild>
        where TChild : IEntity<TParent, TChild>
        where TParent : AEntity<TParent>
    {
        long Identificator();

        TChild Update(TChild entity);
    }
}
