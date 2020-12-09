namespace Lab12.Additionally
{
    class BiTree : Collection.BiTree.BiTree<string>
    {
        private int CountOnChar(char symbol, Collection.BiTree.Node<string> node)
        {
            if (node != null)
                return node.Data[0] == symbol ? 1 : 0
                    + CountOnChar(symbol, node.Left)
                    + CountOnChar(symbol, node.Right);
            else
                return 0;
        }

        public int CountOnChar(char symbol)
            => CountOnChar(symbol, Root);
    }
}
