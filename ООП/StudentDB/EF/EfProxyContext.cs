namespace EF
{
    public class EfProxyContext : AProxyContext
    {
        public EfProxyContext() : base(new EfContext()) { }
    }
}
