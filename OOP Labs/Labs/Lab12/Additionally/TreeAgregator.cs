namespace Lab12.Additionally
{
    internal class TreeAgregator
    {
        private BiTree m_Tree;

        public bool Empty => m_Tree == null;

        public void Formation(string[] nodes)
        {
            m_Tree = new BiTree();
            foreach (string item in nodes)
                m_Tree.Add(item);
        }

        public void ToBalance()
        {

        }

        public void ToSearch()
        {

        }

        public int CountOnChar(char symbol)
            => m_Tree.CountOnChar(symbol);

        public void Remove()
            => m_Tree = null;

        public override string ToString()
            => m_Tree.ToString();
    }
}
