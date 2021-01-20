using Model;

namespace ADO
{
    public class AdoProxyOperation : AProxyOperation
    {
        public AdoProxyOperation() : base(new AdoOperation()) { }
    }
}
