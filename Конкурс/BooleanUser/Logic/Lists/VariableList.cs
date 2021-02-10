using Logic.Visuals;
using System.Collections.ObjectModel;

namespace Logic.Lists
{
    public class VariableList : ObservableCollection<VariableVisual>
    {
        public virtual new void Add(VariableVisual variable)
        {
            base.Add(variable);
        }
    }
}
