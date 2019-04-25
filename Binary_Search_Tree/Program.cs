using System;

namespace Binary_Search_Tree
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Key { get; set; }

        public Node(int _key)
        {
            Key = _key;
        }
    }

    public class BST
    {
        public Node root { get; set; }

        public BST(Node root)
        {
            this.root = root;
        }

        public Node Search(int _key)
        {
            return SearchRec(root, _key);
        }
        private Node SearchRec(Node _root, int _key)
        {
            if (_root == null || _root.Key == _key)
            {
                return _root;
            }

            
            if (_key <= _root.Key)
            {
                return SearchRec(_root.Left, _key);
            }
            return SearchRec(_root.Right, _key);
        }

        public void Insert(int _key)
        {
            if (root == null)
            {
                root = new Node(_key);
            }
            else
            {
                root = InsertRec(root, _key);
            }
        }

        private Node InsertRec(Node _root, int _key)
        {
            if (_root == null)
            {
                
                _root = new Node(_key);
                return _root;
            }

            if (_key>_root.Key)
            {
                _root.Right = InsertRec(_root.Right, _key);
            }
            else if (_key <= _root.Key)
            {
                _root.Left = InsertRec(_root.Left, _key);
            }

            return _root;
        }

        public void DeleteKey(int _key)
        {
            root = DeleteRec(root, _key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_root">The tree you want to search your key in</param>
        /// <param name="_key">The element you want to delete</param>
        /// <returns>The modified tree after the specific node is deleted</returns>
        private Node DeleteRec(Node _root, int _key)
        {
            // Base case: If the tree is empty
            if (_root == null) return null;

            if (_key < _root.Key)
            {
                _root.Left = DeleteRec(_root.Left, _key);
            }
            else if (_key > _root.Key)
            {
                _root.Right = DeleteRec(_root.Right, _key);
            }
            else
            {
                if (_root.Left == null)
                {
                    return _root.Right;
                }
                else if (_root.Right == null)
                {
                    return _root.Left;
                }
                
                // Node with two children: get the inorder successor (smallest in the right subtree)
                _root.Key = MinValue(_root.Right);
                _root.Right = DeleteRec(_root.Right, _root.Key);
            }
            
            return _root;
        }

        private Node MinNode(Node _localRoot)
        {
            int minv = _localRoot.Key;
            while (_localRoot.Left != null)
            {
                minv = _localRoot.Left.Key;
                _localRoot = _localRoot.Left;
            }

            return _localRoot;
        }
        private int MinValue(Node _root)
        {
            return MinNode(_root).Key;
        }

        /// <summary>
        /// The first implementation of the successor (The second one needs parent node)
        /// </summary>
        /// <param name="_root"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public Node InOrderSuccessor(Node _root,Node n)
        {
            if (n.Right != null)
            {
                return MinNode(n.Right);
            }

            Node succ = null;
            while (_root!=null)
            {
                if (n.Key < _root.Key)
                {
                    succ = _root;
                    _root = _root.Left;
                }
                else if (n.Key > _root.Key)
                {
                    _root = _root.Right;
                }
                else
                {
                    break;
                }
            }

            return succ;
        }

        public void InOrderTreeWalk()
        {
            InOrderTreeWalkRecur(root);
        }

        private void InOrderTreeWalkRecur(Node _root)
        {
            if (_root != null)
            {
                InOrderTreeWalkRecur(_root.Left);
                Console.WriteLine(_root.Key);
                InOrderTreeWalkRecur(_root.Right);
            }
            
        }

        public Node Minimum()
        {
            if (root == null)
            {
                Console.WriteLine("The tree doesn't have any element yet");
                return null;
            }
            Node _localRoot = root;
            while (_localRoot.Left!=null)
            {
                _localRoot = _localRoot.Left;
            }

            return _localRoot;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST(new Node(10));
            tree.DeleteKey(10);
//            tree.Minimum();
            tree.Insert(30);
            Console.WriteLine(tree.Minimum().Key);
            
//            tree.Insert(20);
//            tree.Insert(30);
//            tree.Insert(5);
//            tree.Insert(7);
//            tree.InOrderTreeWalk();
//            Console.WriteLine(tree.Minimum().Key);

//            Node nodeToSearch = tree.Search(20);
//            if (nodeToSearch == null)
//            {
//                Console.WriteLine("Didn't find the element");
//            }
//            else
//            {
//                Console.WriteLine("Find the node");
//            }
//            tree.DeleteKey(30);
//            Node nodeToSearchAgain = tree.Search(20);
//            if (nodeToSearchAgain == null)
//            {
//                Console.WriteLine("Didn't find the element");
//            }
//            else
//            {
//                Console.WriteLine("Find the node");
//            }

        }
    }
}