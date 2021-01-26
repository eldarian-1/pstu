using Model.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfUi.Wrappers
{
    class MarkJournal : ObservableCollection<MarkEntry>
    {
        public MarkJournal(IEnumerable<Mark> journal, MainWindow main)
        {
            foreach (var item in journal)
                Add(new MarkEntry(item, main));
        }
    }
}
