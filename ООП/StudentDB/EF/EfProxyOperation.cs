using Model;

namespace EF
{
    public class EfProxyOperation : AProxyOperation
    {
        public EfProxyOperation() : base(new EfOperation()) { }
    }
}
