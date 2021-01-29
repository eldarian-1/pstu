using Model.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfUi
{
    class MarkJournal : ObservableCollection<MarkEntry>
    {
        public MarkJournal(IEnumerable<Mark> journal, Mediator mediator)
        {
            foreach (var item in journal)
                Add(new MarkEntry(item, mediator));
        }
    }
}
