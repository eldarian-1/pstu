using Entity;
using ADO;
using EF;

namespace Controller
{
    public class Facade
    {
        private bool m_IsEF;
        private IDBContext m_Context;

        public Facade()
        {
            m_IsEF = true;
            m_Context = new EfProxyContext();
        }

        public void ChangeContext()
        {
            m_IsEF = !m_IsEF;
            m_Context = m_IsEF ? new EfProxyContext()
                : new AdoProxyContext() as IDBContext;
        }
    }
}
