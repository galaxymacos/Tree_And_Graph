namespace Binary_Search_Tree_With_Parent
{
    public class Node
    {
        public int Key { get; set; }
        public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int _key)
        {
            Key = _key;
            Parent = null;
            Left = null;
            Right = null;
        }
    }
}