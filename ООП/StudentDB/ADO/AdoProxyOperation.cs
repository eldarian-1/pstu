using Model;

namespace ADO
{
    public class AdoProxyOperation : AProxyOperation
    {
        public AdoProxyOperation()
        {
            Current = new AdoOperation();
        }
    }
}
