using Model.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Controller
{
    public class MarkJournal : ObservableCollection<MarkEntry>
    {
        public MarkJournal(IEnumerable<Mark> journal, IMediator mediator)
        {
            foreach (var item in journal)
                Add(new MarkEntry(item, mediator));
        }
    }
}
