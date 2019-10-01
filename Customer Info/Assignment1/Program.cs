using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Matt Hoffman 
//BIT 265
//Spring 2019
namespace Assignment1
{
    class Program
    {
        //shows how the merge sort is working
        static void Main(string[] args)
        {
            double[] arra = new double[10];
            arra[0] = 4.3;
            arra[1] = 4.65;
            arra[2] = 4.14;
            arra[3] = 0;
            arra[4] = 15.38;
            arra[5] = 6.95;
            arra[6] = 94.64;
            arra[7] = 2.45;
            arra[8] = 4.2;
            arra[9] = 12.666;
            Merge m = new Merge();
            m.MergeSort(arra);
            for (int i = 0; i < arra.Length; i++)
                Console.WriteLine(arra[i]);
        }
    }

    enum Menu
    {
        Add_Customer,
        Remove_Customer,
        View_Customer,
        Edit_Customer,
        Quit
    }
    // currently not working.
    class UserInput
    {
        new AVL A = new AVL();
        public void interaction()
        {
            int choice;

            do
            {
                Console.WriteLine("Your Options.");
                Console.WriteLine("{0} : Add a new customer.", (int)Menu.Add_Customer);
                Console.WriteLine("{0} : Remove a customer.", (int)Menu.Remove_Customer);
                Console.WriteLine("{0} : View find a customer.", (int)Menu.View_Customer);
                Console.WriteLine("{0} : Edit a customer.", (int)Menu.Edit_Customer);
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please type a valid number");
                    continue;
                }
                switch ((Menu)choice)
                {
                    //case Menu.Add_Customer:

                }
            } while (choice != (int)Menu.Quit);
        }
        public void AddToAVLTree()
        {
            string x;
            double[] y = new double[50];
            int z = 0;
            double value;
            Console.WriteLine("Please enter the customers name");
            x = Console.ReadLine();
            do
            {
                Console.WriteLine("Please enter the dates you would like to add as a decimal. Example: march 14th would be 3.14.  When you are done type -1.");
                if (z == 49)
                {
                    Console.WriteLine("Sorry the list of dates is full!");
                    return;
                }
                //value = Double.TryParse(Console.ReadLine(), out y[z]);
                value = -1;
            } while (value != -1);
        }
    }
    // Here is the webiste where I found my AVL tree https://simpledevcode.wordpress.com/2014/09/16/avl-tree-in-c/ 
    class AVL
    {
        // I had to edit a good amount of it to work around having strings as the values instead of ints.
        class Node
        {
            public string data;
            public double[] dates = new double[50];
            public Node left;
            public Node right;
            public Node(string data)
            {
                this.data = data;
            }
            public Node(string data, double[] dates)
            {
                this.data = data;
                this.dates = dates;
            }
        }
        Node root;
        //public AVL()
        //{
        //}
        public void Add(string data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }
        private Node RecursiveInsert(Node current, Node n)
        {
         
            if (current == null)
            {
                current = n;
                return current;
            }
            int test = string.Compare(current.data, n.data);
            if (test < 0)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (test > 0)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }
        private Node balance_tree(Node current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        public void Delete(string target)
        {//and here
            root = Delete(root, target);
        }
        private Node Delete(Node current, string target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                int test = string.Compare(current.data, target);
                //left subtree
                if (test < 0)
                {
                    current.left = Delete(current.left, target);
                    if (balance_factor(current) == -2)//here
                    {
                        if (balance_factor(current.right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //right subtree
                else if (test > 0)
                {
                    current.right = Delete(current.right, target);
                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.right != null)
                    {
                        //delete its inorder successor
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        current.right = Delete(current.right, parent.data);
                        if (balance_factor(current) == 2)//rebalancing
                        {
                            if (balance_factor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.left;
                    }
                }
            }
            return current;
        }
        public void Find(string key)
        {
            if (Find(key, root).data == key)
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }
        private Node Find(string target, Node current)
        {
            int test = string.Compare(current.data, target);
            if (test < 0)
            {
                if (target == current.data)
                {
                    return current;
                }
                else
                    return Find(target, current.left);
            }
            else
            {
                if (target == current.data)
                {
                    return current;
                }
                else
                    return Find(target, current.right);
            }

        }
        //From here down were not elements that I implemented but left in in case it would stop the AVL tree from functioning.
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplayTree(current.right);
            }
        }
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
    class Merge
    {
        public void MergeSort(double[] array)
        {
            if (array != null && array.Length > 1)
            {
                double[] temp = new double[array.Length];
                MergeSort_Internal(array, 0, array.Length - 1, temp);
            }
        }

        private void MergeSort_Internal(double[] arrayToSort, int beginning, int ending, double[] temp)
        {
            //This is where we split up the lists in order to get them down to single item arrays and then we use the MergeLists to began to put them together in order.
            if (beginning < ending)
            {
                int middle = (beginning+ ending) / 2;
                MergeSort_Internal(arrayToSort, beginning, middle, temp);
                MergeSort_Internal(arrayToSort, middle + 1, ending, temp);
                MergeLists(arrayToSort, beginning, middle, middle + 1, ending, temp);
            }
        }
        
        private void MergeLists(double[] arrayToSort, int firstLeft, int lastLeft, int firstRight, int lastRight, double[] temp)
        {
            // we'll merge things into the temp array to sort them

            // then copy them back into arrayToSort
            int locationInTemp = 0;
            int currentFirstLeft = firstLeft;
            int currentFirstRight = firstRight;

            bool LeftRemaining = currentFirstLeft <= lastLeft;
            bool RightRemaining = currentFirstRight <= lastRight;
            // This runs if leftremaining or right remaining are > 1.
            while (LeftRemaining || RightRemaining)
            {
                // this runs if leftremaining and right remaining are > 1
                if (LeftRemaining && RightRemaining)
                {
                    // This makes it so the small of the numbers goes first 
                    if (arrayToSort[currentFirstLeft] <= arrayToSort[currentFirstRight])
                    {
                        temp[locationInTemp] = arrayToSort[currentFirstLeft];
                        locationInTemp++;
                        currentFirstLeft++;
                    }
                    else
                    {
                        temp[locationInTemp++] = arrayToSort[currentFirstRight++];
                    }
                }
                //This will make it so if one of the arrays it out of values the other puts in its remaining value.
                else if (LeftRemaining)
                {
                    temp[locationInTemp++] = arrayToSort[currentFirstLeft++];
                }
                else 
                {
                    temp[locationInTemp++] = arrayToSort[currentFirstRight++];
                }

                LeftRemaining = currentFirstLeft <= lastLeft;
                RightRemaining = currentFirstRight <= lastRight;
            }
            // posts the new sorted array over the old array.
            int howManyToCopy = lastRight - firstLeft + 1;
            for (int i = 0; i < howManyToCopy; i++)
            {
                arrayToSort[firstLeft + i] = temp[i];
            }

        }
    }
}
