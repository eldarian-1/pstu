using Entity;
using System.Collections.Generic;

namespace EngineCollection
{
    class EngineQueue : Queue<IEngine>, IEngineCollection
    {
        public IEngine[] ToArray()
        {

        }
    }
}
