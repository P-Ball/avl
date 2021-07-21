using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

    Taken from https://simpledevcode.wordpress.com/2014/09/16/avl-tree-in-c/

    with modifications for C#, 

  */
namespace AVL
{
    class Node
    {
        //public int key;  //  we combine our key and value as the same thing but they could be distinct
        public int value;
        public Node left;
        public Node right;
        public int balance=0; // Students need to worry about this
        // public Node Parent;  //might be useful
  


    }

    class AVLTree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
                root = balance_tree(root);
            }
            else if (v > root.value)
            {
                root.right = insert(root.right, v);
                root = balance_tree(root);
            }

            return root;
        }

        // This is the code which actually balances the tree, it calls the different cases
        // but RotateLeftLeft, RotateLeftRight, and RotateRightLeft are to be filled in by the student.  
        private Node balance_tree(Node root)
        {
            int b_factor = balance_factor(root);// balance factor is left_height - right_height
            if (b_factor > 1)
            {
                //we have to rotate right
                if (balance_factor(root.left) > 0)
                {
                    //simple right rotation
                    root = RotateLeftLeft(root);
                }
                else
                {
                    //straighten the bend first, and rotate right.
                    root = RotateLeftRight(root);
                }
            }
            else if (b_factor < -1)
            {
                //we have to rotate left
                if (balance_factor(root.right) > 0)
                {
                    //straighten the bend and then rotate left.
                    root = RotateRightLeft(root);
                }
                else
                {
                    //use this as a template
                    //This is a simple left rotation
                    root = RotateRightRight(root);
                }
            }
            return root;
        }//end balance_tree

        public int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = Math.Max(l, r);
                height = m + 1;
            }
            return height;
        }
        public int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        //Level order traversal repurposed from http://www.geeksforgeeks.org/level-order-tree-traversal/
        public void printLevelOrder(Node root)
        {
            int treeHeight = getHeight(root);
            int i;
            string temp;//formatting 
            for (i = 1; i <= treeHeight; i++)
            {
                Console.WriteLine();
                temp = new string(' ',4*(treeHeight - i));//formatting
                Console.Write(temp);//the formatting being printed
                printGivenLevel(root, i);
            }
        }
        public void printGivenLevel(Node root, int level)
        {
            //The formatting should probably happen here not in printLevelOrder
            //
            
            if (root == null)
            {
                Console.Write(" ni ");
                return;
            }
            if (level == 1)
                Console.Write(" " + root.value+ " ");
            else if (level > 1)
            {
                printGivenLevel(root.left, level - 1);
                printGivenLevel(root.right, level - 1);
                
            }
            
        }
        public string PreOrder(Node root)
        {
            if (root == null)
            {
                return "nil";
            }
            return root.value.ToString() + " " + PreOrder(root.left) + " " + PreOrder(root.right);


        }
        //AVL Lab

        //
        // right sub tree of a right subtree case

        // Note that you should use the diagram from the notes (slides 18 as of this writing) to try and implement the following
        //This handles the case where the tree is in the right-right case.
        //We rotate left.
        public Node RotateRightRight(Node parent)
        {
            //pivot is the new root of the sub tree.  We are rotating left.
            Node pivot = parent.right;
            //Move the pivot's left child to the parent's right child.
            parent.right = pivot.left;
            //put the parent to the left left of the pivot, rotating left.
            pivot.left = parent;
            //return the new parent.
            return pivot;
        }
       
         // This handles the case where the tree is out of balance with nodes in the left-left case.  

         //
        public Node RotateLeftLeft(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent; 
            return pivot; // this is wrong student needs to fix it
        }
        //This handles the case where the out of balance node is in the left-right case.

        public Node RotateLeftRight(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            parent.right = parent; 
            return pivot;// this is wrong student needs to fix it
        }
        //This handles the case where the out of balance node is in the right-left case.

        public Node RotateRightLeft(Node parent)
        {
            Node pivot = parent.right;
            pivot.right = parent.left;
            parent.left = parent;
            return pivot;// this is wrong student needs to fix it
        }





    }//end class AVL Tree
}//end namespace
