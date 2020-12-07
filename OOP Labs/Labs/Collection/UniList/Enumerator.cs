using System.Collections;
using System.Collections.Generic;

namespace Collection.UniList
{
    internal class Enumerator<T> : IEnumerator<T>
    {
        private UniList<T> m_List;
        private Node<T> m_Current;

        object IEnumerator.Current => m_Current.Data;

        public T Current => m_Current.Data;

        public Enumerator(UniList<T> list)
        {
            m_List = list;
            m_Current = list.Head;
        }

        public bool MoveNext()
        {
            bool flag = m_Current != null;
            if (flag)
                m_Current = m_Current.Next;
            return flag;
        }

        public void Reset()
        {
            m_Current = m_List.Head;
        }

        public void Dispose() {}
    }
}
