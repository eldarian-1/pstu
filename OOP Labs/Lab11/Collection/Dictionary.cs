using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICloneable
    {
        private class Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private Dictionary<TKey, TValue> m_Dictionary;
            private IEnumerator<TKey> m_EnumKeys;

            public KeyValuePair<TKey, TValue> Current
                => new KeyValuePair<TKey, TValue>
                (m_EnumKeys.Current, m_Dictionary[m_EnumKeys.Current]);
            object IEnumerator.Current => m_EnumKeys;

            public Enumerator(Dictionary<TKey, TValue> dictionary)
            {
                m_Dictionary = dictionary;
                m_EnumKeys = dictionary.Keys.GetEnumerator();
            }

            public void Dispose()
                => m_EnumKeys.Dispose();

            public bool MoveNext()
                => m_EnumKeys.MoveNext();

            public void Reset()
                => m_EnumKeys.Reset();
        }

        public TValue this[TKey key]
        {
            get
            {
                int i = 0;
                foreach (TKey tKey in Keys)
                {
                    if (tKey.Equals(key))
                        return (TValue)((Values as IList)[i]);
                    ++i;
                }
                throw new Exception();
            }
            set
            {
                int i = 0;
                foreach (TKey tKey in Keys)
                {
                    if (tKey.Equals(key))
                    {
                        (Values as IList)[i] = value;
                        return;
                    }
                    ++i;
                }
                throw new Exception();
            }
        }

        public ICollection<TKey> Keys { get; private set; }

        public ICollection<TValue> Values { get; private set; }

        public int Count => Keys.Count;

        public bool IsReadOnly => true;

        public void Add(TKey key, TValue value)
        {
            Keys.Add(key);
            Values.Add(value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Keys.Add(item.Key);
            Values.Add(item.Value);
        }

        public void Clear()
        {
            Keys.Clear();
            Values.Clear();
        }

        public object Clone()
        {
            Dictionary<TKey, TValue> tDictionary = new Dictionary<TKey, TValue>();
            foreach (TKey key in Keys)
                tDictionary.Add(key, this[key]);
            return tDictionary;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            bool flag = ContainsKey(item.Key);
            if (flag)
                flag = this[item.Key].Equals(item.Value);
            return flag;

        }

        public bool ContainsKey(TKey key)
            => Keys.Contains(key);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            for (int i = index, n = array.Length; i < n; i++)
                Add(array[i].Key, array[i].Value);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            => new Enumerator(this);

        public bool Remove(TKey key)
        {
            int i = 0, n = Keys.Count;
            IEnumerator<TKey> ek = Keys.GetEnumerator();
            IEnumerator<TValue> ev = Values.GetEnumerator();

            while (i++ < n)
            {
                if (ek.Current.Equals(key))
                    break;
                ek.MoveNext();
            }

            if(i == Keys.Count || !Keys.Remove(key))
                return false;

            while (i-- > 0)
                ev.MoveNext();

            return Values.Remove(ev.Current);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            bool flag = Keys.Contains(item.Key) && Values.Contains(item.Value);
            if(flag)
            {
                Keys.Remove(item.Key);
                Values.Remove(item.Value);
            }
            return flag;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default;
            bool flag = Keys.Contains(key);
            if (flag)
                value = this[key];
            return flag;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
