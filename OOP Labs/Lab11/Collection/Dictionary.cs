using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICloneable
    {
        private class Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            public KeyValuePair<TKey, TValue> Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
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
            set => throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
            => Keys.Contains(key);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            for (int i = index, n = array.Length; i < n; i++)
                Add(array[i].Key, array[i].Value);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
