namespace Collection.BiList
{
    internal class Node<T>
    {
        public Node<T> Next { get; set; }

        public Node<T> Prev { get; set; }

        public T Data { get; set; }

    }
}
