using System;

namespace RedBlackTreeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree tree = new RedBlackTree();
            
            // Add elements to the tree
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);

            // Print the tree
            PrintTree(tree.Root, "", true);

            // Test the tree with different inputs
            tree.Insert(15);
            PrintTree(tree.Root, "", true);

            tree.Insert(35);
            PrintTree(tree.Root, "", true);

            tree.Insert(45);
            PrintTree(tree.Root, "", true);
        }

        static void PrintTree(RedBlackTreeNode node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("└─ ");
                    indent += "  ";
                }
                else
                {
                    Console.Write("├─ ");
                    indent += "│ ";
                }
                var color = node.IsBlack ? "Black" : "Red";
                Console.WriteLine($"{node.Key} ({color})");

                PrintTree(node.LeftChild, indent, false);
                PrintTree(node.RightChild, indent, true);
            }
        }
    }
}
