using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab8
{
    [Serializable]
    public class ClientList : ObservableCollection<Client>
    {
        public ClientList()
            : base() { }

        public ClientList(List<Client> collection)
            : base(collection) { }

        public ClientList(IEnumerable<Client> collection)
            : base(collection) { }

        public ClientList GetListByName(string name)
        {
            ClientList list = new ClientList();
            for (int i = 0, n = Count; i < n; ++i)
                if (this[i].IsBeginOn(name))
                    list.Add(this[i]);
            return list;
        }

        public ClientList GetListByPeriod(string period)
        {
            ClientList list = new ClientList();
            for (int i = 0, n = Count; i < n; ++i)
                if (this[i].Period == period)
                    list.Add(this[i]);
            return list;
        }
    }
}
