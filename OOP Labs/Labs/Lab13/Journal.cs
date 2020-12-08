using System.Collections.Generic;

namespace Lab13
{
    internal class Journal
    {
        private IList<JournalEntry> m_Entries;

        public Journal()
        {
            m_Entries = new List<JournalEntry>();
        }

        public void CountChange(object source, StackHandlerEventArgs args)
        {
            JournalEntry entry = new JournalEntry();
            m_Entries.Add(entry);
        }

        public void ReferenceChange(object source, StackHandlerEventArgs args)
        {
            JournalEntry entry = new JournalEntry();
            m_Entries.Add(entry);
        }

        public override string ToString()
        {
            string result = "";
            foreach (JournalEntry item in m_Entries)
                result += item + "\n";
            return result;
        }
    }
}
