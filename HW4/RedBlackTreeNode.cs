namespace RedBlackTreeExample
{
    public class RedBlackTreeNode
    {
        public int Key { get; set; }
        public bool IsBlack { get; set; }
        public RedBlackTreeNode? Parent { get; set; }
        public RedBlackTreeNode? LeftChild { get; set; }
        public RedBlackTreeNode? RightChild { get; set; }


        public RedBlackTreeNode(int key)
        {
            Key = key;
            IsBlack = false;
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }
    }
}

