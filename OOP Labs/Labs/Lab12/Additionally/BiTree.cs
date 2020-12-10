namespace Lab12.Additionally
{
    class BiTree : Collection.BiTree.BiTree<string>
    {
        private const string c_EmptyTree = "Дерево не содержит ветвей";

        private int CountOnChar(Collection.BiTree.Node<string> node, char symbol)
        {
            if (node != null)
                return (node.Data[0] == symbol ? 1 : 0)
                    + CountOnChar(node.Left, symbol)
                    + CountOnChar(node.Right, symbol);
            else
                return 0;
        }

        public int CountOnChar(char symbol)
            => CountOnChar(Root, symbol);

        private string TreeToString(Collection.BiTree.Node<string> node, string prefix)
        {
            if (node != null)
                return (node == Root ? "" : "\n")
                    + prefix + node.Data
                    + TreeToString(node.Left, prefix + "-")
                    + TreeToString(node.Right, prefix + "-");
            else
                return "";
        }

        public override string ToString()
        {
            string result;
            if (Root != null)
                result = TreeToString(Root, "");
            else
                result = c_EmptyTree;
            return result;
        }
    }
}
