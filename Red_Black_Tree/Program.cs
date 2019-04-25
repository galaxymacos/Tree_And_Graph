using System;

namespace Red_Black_Tree
{
    public class Node
    {
        public int Key { get; set; }
        public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Color Color { get; set; }
    }

    public enum Color
    {
        Black,
        Red
    }

    public class RBT
    {
        public Node root;

        private void LeftRotate(RBT tree, Node nodeRotated)
        {
            Node rightChild = nodeRotated.Right;
            nodeRotated.Right = rightChild.Left;
            if (rightChild.Left != null)
            {
                rightChild.Left.Parent = nodeRotated;
            }
            
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}