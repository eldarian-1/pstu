namespace EF
{
    public class EfProxyContext : AContext
    {
        public EfProxyContext() : base(new EfContext()) { }
    }
}
