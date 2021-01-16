using EF;

namespace ADO
{
    public class AdoProxyContext : AProxyContext
    {
        public AdoProxyContext() : base(new AdoContext()) { }
    }
}
