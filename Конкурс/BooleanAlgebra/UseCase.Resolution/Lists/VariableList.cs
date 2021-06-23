using Model.Logic;
using UseCase.Resolution.Visuals;
using System.Collections.ObjectModel;

namespace UseCase.Resolution.Lists
{
    public class VariableList : ObservableCollection<VariableVisual>
    {
        public static VariableList Variables { get; protected set; }

        private int m_Index;
        private TruthTable m_TruthTable;

        public VariableList() : base()
        {
            Variables = this;
        }

        public new void Add(VariableVisual variable)
        {
            base.Add(variable);
            m_TruthTable = new TruthTable(Count);
            Reset();
        }

        public void Reset()
        {
            m_Index = 0;
            Next();
        }

        public int Size => m_TruthTable.Changes;

        public void Next()
        {
            if (m_Index == m_TruthTable.Changes)
            {
                Reset();
                return;
            }
            for (int i = 0, n = m_TruthTable.Variables; i < n; ++i)
                Variables[i].Value = m_TruthTable[m_Index, i];
            ++m_Index;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0, n = Count; i < n; ++i)
                if (this[i].IsVisible)
                    result += (i > 0 ? ", " : "") + this[i];
            return result;
        }
    }
}
