using Entity;
using ADO;
using EF;

namespace Controller
{
    public class Facade : AContext
    {
        private bool m_IsEF;

        public Facade() : base(new EfProxyContext())
        {
            m_IsEF = true;
        }

        public void ChangeContext()
        {
            m_IsEF = !m_IsEF;
            Operation = m_IsEF ? new EfProxyContext()
                : new AdoProxyContext() as IOperations;
        }

        public void UpdateStudent(Student student)
        {

        }

        public void DeleteStudent(Student student)
        {

        }
    }
}
