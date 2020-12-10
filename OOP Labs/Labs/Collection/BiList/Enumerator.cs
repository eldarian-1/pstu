﻿using System.Collections;
using System.Collections.Generic;

namespace Collection.BiList
{
    internal class Enumerator<T> : IEnumerator<T>
    {
        private BiList<T> m_List;
        private Node<T> m_Current;

        object IEnumerator.Current => m_Current.Data;

        public T Current => m_Current.Data;

        public Enumerator(BiList<T> list)
        {
            m_List = list;
        }

        public bool MoveNext()
        {
            bool flag;
            if (m_Current == null)
            {
                m_Current = m_List.Head;
                flag = true;
            }
            else
            {
                flag = m_Current.Next != null;
                if (flag)
                    m_Current = m_Current.Next;
            }
            return flag;
        }

        public void Reset()
        {
            m_Current = m_List.Head;
        }

        public void Dispose() {}
    }
}
