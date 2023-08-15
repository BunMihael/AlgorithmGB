using System;

namespace RedBlackTreeExample
{
    public class RedBlackTree
    {
        // The root of the Red-Black Tree
        public RedBlackTreeNode Root { get; private set; }

        // Constructor to initialize an empty Red-Black Tree
        public RedBlackTree()
        {
            Root = null;
        }

        // Method to insert a new node with a given key into the Red-Black Tree
        public void Insert(int key)
        {
            RedBlackTreeNode newNode = new RedBlackTreeNode(key);

            // If the tree is empty, make the new node the root
            if (Root == null)
            {
                Root = newNode;
                Root.IsBlack = true;
                return;
            }

            RedBlackTreeNode current = Root;
            RedBlackTreeNode parent = null;

            // Find the appropriate position for the new node
            while (current != null)
            {
                parent = current;
                if (key < current.Key)
                {
                    current = current.LeftChild;
                }
                else if (key > current.Key)
                {
                    current = current.RightChild;
                }
                else
                {
                    return;
                }
            }

            // Link the new node with its parent
            newNode.Parent = parent;
            if (key < parent.Key)
            {
                parent.LeftChild = newNode;
            }
            else
            {
                parent.RightChild = newNode;
            }

            // Balance the tree after the insertion
            BalanceAfterInsert(newNode);
        }

        // Method to balance the Red-Black Tree after the insertion of a new node
        private void BalanceAfterInsert(RedBlackTreeNode node)
        {
            // Iterate while the parent of the current node is red
            while (node.Parent != null && !node.Parent.IsBlack)
            {
                // Check if the parent of the current node is the left child of the grandparent
                if (node.Parent == node.Parent.Parent.LeftChild)
                {
                    var uncle = node.Parent.Parent.RightChild;
                    if (uncle != null && !uncle.IsBlack)
                    {
                        node.Parent.IsBlack = true;
                        uncle.IsBlack = true;
                        node.Parent.Parent.IsBlack = false;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.RightChild)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.IsBlack = true;
                        node.Parent.Parent.IsBlack = false;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    var uncle = node.Parent.Parent.LeftChild;
                    if (uncle != null && !uncle.IsBlack)
                    {
                        node.Parent.IsBlack = true;
                        uncle.IsBlack = true;
                        node.Parent.Parent.IsBlack = false;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.LeftChild)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.IsBlack = true;
                        node.Parent.Parent.IsBlack = false;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            Root.IsBlack = true;
        }

        // Method to perform a left rotation on a given node
        private void RotateLeft(RedBlackTreeNode node)
        {
            RedBlackTreeNode rightChildTemp = node.RightChild;
            node.RightChild = rightChildTemp.LeftChild;
            if (rightChildTemp.LeftChild != null)
                rightChildTemp.LeftChild.Parent = node;
            rightChildTemp.Parent = node.Parent;
            if (node.Parent == null)
                Root = rightChildTemp;
            else if (node == node.Parent.LeftChild)
                node.Parent.LeftChild = rightChildTemp;
            else
                node.Parent.RightChild = rightChildTemp;
            rightChildTemp.LeftChild = node;
            node.Parent = rightChildTemp;
        }

        // Method to perform a right rotation on a given node
        private void RotateRight(RedBlackTreeNode node)
        {
            RedBlackTreeNode leftChildTemp = node.LeftChild;
            node.LeftChild = leftChildTemp.RightChild;
            if (leftChildTemp.RightChild != null)
                leftChildTemp.RightChild.Parent = node;
            leftChildTemp.Parent = node.Parent;
            if (node.Parent == null)
                Root = leftChildTemp;
            else if (node == node.Parent.LeftChild)
                node.Parent.LeftChild = leftChildTemp;
            else
                node.Parent.RightChild = leftChildTemp;
            leftChildTemp.RightChild = node;
            node.Parent = leftChildTemp;
        }
    }
}
