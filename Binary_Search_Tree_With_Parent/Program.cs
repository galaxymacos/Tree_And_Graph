using System;

namespace Binary_Search_Tree_With_Parent
{
    public class BST
    {
        public Node root;

        public void InOrderTreeWalk()
        {
            InOrderTreeWalkRec(root);
        }

        private void InOrderTreeWalkRec(Node _root)
        {
            if (_root == null) return;
            
            InOrderTreeWalkRec(_root.Left);
            Console.WriteLine(_root.Key);
            InOrderTreeWalkRec(_root.Right);
        }

        public Node SearchUsingRecursion(int _key)
        {
            return SearchRec(root, _key);
        }

        private Node SearchRec(Node _root, in int _key)
        {
            if (_root == null || _root.Key == _key)
            {
                return _root;
            }

            if (_key < root.Key)
            {
                return SearchRec(_root.Left, _key);
            }
            else
            {
                return SearchRec(_root.Right, _key);
            }
        }

        public Node SearchUsingIteration(int _key)
        {
            Node _root = root;
            while (_root != null && _root.Key != _key)
            {
                if (_key < _root.Key)
                {
                    _root = _root.Left;
                }
                else
                {
                    _root = _root.Right;
                }
            }

            return _root;
        }

        public Node Minimum(Node node)
        {
            Node _root = node;
            while (_root.Left != null)
            {
                _root = _root.Left;
            }

            return _root;
        }
        
        public Node Maximum(Node node)
        {
            Node _root = node;
            while (_root.Right != null)
            {
                _root = _root.Right;
            }

            return _root;
        }

        public void Insert(int _key)
        {
            InsertRec(this, new Node(_key));
        }

        private void InsertRec(BST t, Node newNode)
        {
            Node futureParent = null;
            Node _root = t.root;
            while (_root!=null)
            {
                futureParent = _root;
                if (newNode.Key < _root.Key)
                {
                    _root = _root.Left;
                }
                else
                {
                    _root = _root.Right;
                }
            }

            newNode.Parent = futureParent;
            if (futureParent == null)
            {
                t.root = newNode;
            }
            else if (newNode.Key < futureParent.Key)
            {
                futureParent.Left = newNode;
            }
            else
            {
                futureParent.Right = newNode;
            }

        }

        public void Delete(int _key)
        {
            
        }

        private void Transplant(BST t, Node NToBeTransplanted, Node postNode)
        {
            if (NToBeTransplanted.Parent == null)
            {
                t.root = postNode;
            }
            else if (NToBeTransplanted == NToBeTransplanted.Parent.Left)
            {
                NToBeTransplanted.Parent.Left = postNode;
            }
            else
            {
                NToBeTransplanted.Parent.Right = postNode;
            }

            if (postNode != null)
            {
                postNode.Parent = NToBeTransplanted.Parent;
            }
        }
        
        public void Delete(BST t, Node nodeToDelete)
        {
            // First case
            if (nodeToDelete.Right == null)
            {
                Transplant(t,nodeToDelete,nodeToDelete.Left);
            }
            // Second case
            else if (nodeToDelete.Left == null)
            {
                Transplant(t,nodeToDelete, nodeToDelete.Right);
            }
            // Third case
            else
            {
                Node MinimumNodeFromRightTree = Minimum(nodeToDelete.Right);
                if (MinimumNodeFromRightTree.Parent != nodeToDelete)
                {
                    
                    Transplant(t,MinimumNodeFromRightTree,MinimumNodeFromRightTree.Right);
                    MinimumNodeFromRightTree.Right = nodeToDelete.Right;
                    MinimumNodeFromRightTree.Right.Parent = MinimumNodeFromRightTree;
                }
                // Delete the node
                Transplant(t,nodeToDelete,MinimumNodeFromRightTree);
                MinimumNodeFromRightTree.Left = nodeToDelete.Left;
                MinimumNodeFromRightTree.Left.Parent = MinimumNodeFromRightTree;
            }
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
//            Console.WriteLine(tree.Minimum(tree.root).Key);
            tree.Delete(tree,tree.SearchUsingRecursion(10));
            tree.Delete(tree,tree.SearchUsingRecursion(5));
            tree.InOrderTreeWalk();
        }
    }
}