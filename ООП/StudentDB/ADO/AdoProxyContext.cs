using EF;

namespace ADO
{
    public class AdoProxyContext : AContext
    {
        public AdoProxyContext() : base(new AdoContext()) { }
    }
}
