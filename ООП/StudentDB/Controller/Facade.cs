using EF;
using ADO;
using Mock;
using Model;
using System.Collections.Generic;

namespace Controller
{
    public class Facade : AProxyOperation
    {
        public IList<IOperateable> Operations { get; }

        public Facade() 
        {
            Current = new MockOperation();
            Operations = new List<IOperateable>();
            Operations.Add(Current);
        }
    }
}
