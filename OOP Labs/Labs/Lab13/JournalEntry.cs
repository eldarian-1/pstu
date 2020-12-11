namespace Lab13
{
    internal class JournalEntry
    {
        public JournalEntry(string collection, string editionType)
        {
            Collection = collection;
            EditionType = editionType;
        }

        public string Collection { get; set; }

        public string EditionType { get; set; }

        public override string ToString()
        {
            return Collection + ": " + EditionType;
        }
    }
}
