using Model;

namespace EF
{
    public class EfProxyOperation : AProxyOperation
    {
        public EfProxyOperation()
        {
            Current = new EfOperation();
        }
    }
}
