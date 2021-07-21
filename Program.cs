using System;
using System.Diagnostics;

// BST stolen from  https://gist.github.com/aaronjwood/7e0fc962c5cd898b3181
// including the class file
// Significant modifications by Sri

namespace AVL
{
    


    class AVLTreeDemo
    {
        static void Main(string[] args)
        {
            Node root = null;
            AVLTree avl = new AVLTree();
            int SIZE = 10; // tested on up to 200k elements and it works fine
            int[] testArray = new int[SIZE];
            
            Random rnd = new Random(10);
            Console.WriteLine("Elements to be inserted into the BST");
            for (int i=0; i<SIZE; i++)
            {
                testArray[i] = rnd.Next(1, 100);
                Console.WriteLine(testArray[i]);
            }
            
            for (int i = 0; i < SIZE; i++)
            {
                root = avl.insert(root, testArray[i] );
            }
            Console.WriteLine("Elements in the Tree, in some order");
            Console.WriteLine(avl.PreOrder(root));
            Console.WriteLine("Elements in the Tree, using a level order traversal, yes, I realize the format sucks, cope");
            avl.printLevelOrder(root);

            Console.WriteLine();
            Console.WriteLine("Finally. we print the tree in order on it's side for debugging.");
            //how about this, Sri?
            Print(root, 0);

            Console.ReadKey();
        }//end Main

        // Print
        // Inorder traversal of the BST
        // Time complexity:  O(n)
        // From Professor Patrick
        private static void Print(Node root, int index)
        {
            if (root != null)
            {
                Print(root.right, index + 5);
                Console.WriteLine(new String(' ', index) + root.value.ToString());
                Print(root.left, index + 5);
            }
        }
    }//end class
}//end namespace

