using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class MyDataTree: DataTree
    {

        protected Node root;
        protected Node current;

        public MyDataTree()
        {
            root = null;
            current = null;
        }

        public override bool isEmpty()
        {
            if (root == null)
                return true;
            return false;
        }

        public override Student getData()
        {
            return current.data;
        }


        public override void add(Student student)
        {
            Node firstNode = root;
            Node secondNode = null;
            while (firstNode != null)
            {
                secondNode = firstNode;
                if (student.CompareTo(firstNode.data) == -1)
                    firstNode = firstNode.left;
                else
                    firstNode = firstNode.right;
            }
            Node newNode;
            if (secondNode == null)
            {
                newNode = new Node(student, null);
                root = newNode;
            }
            else if (student.CompareTo(secondNode.data) == -1)
            {
                newNode = new Node(student, secondNode);
                secondNode.left = newNode;
            }
            else
            {
                newNode = new Node(student, secondNode);
                secondNode.right = newNode;
            }
            newNode.setColorRed();
            root.setColorBlack();
            checkTree(newNode);
        }

        protected void checkTree(Node node)
        {
            if (node.parent == null)
                return;

            while (node.parent != null && node.parent.color == Node.RED)
            {
                if (node.parent.parent != null && node.parent == node.parent.parent.left)
                {
                    Node rightNode = node.parent.parent.right;
                    if (rightNode != null && rightNode.color == Node.RED)
                    {
                        node.parent.setColorBlack();
                        rightNode.setColorBlack();
                        node.parent.parent.setColorRed();
                        node = node.parent.parent;
                    }
                    else if (node == node.parent.right)
                    {
                        node = node.parent;
                        leftRotate(node);
                        
                    }
                    else
                    {
                        node.parent.setColorBlack();
                        node.parent.parent.setColorRed();
                        rightRotate(node.parent.parent);
                    }
                }
                else
                {
                    Node leftNode = node.parent.parent.left;
                    if (leftNode != null && leftNode.color == Node.RED)
                    {
                        node.parent.setColorBlack();
                        leftNode.setColorBlack();
                        node.parent.parent.setColorRed();
                        node = node.parent.parent;
                    }
                    else if (node == node.parent.right)
                    {
                        node = node.parent;
                        rightRotate(node);
                    }
                    else
                    {
                        node.parent.setColorBlack();
                        node.parent.parent.setColorRed();
                        leftRotate(node.parent.parent);
                    }
                }  
            }
            root.setColorBlack();
        }      

        protected void leftRotate(Node node)
        {
            if (node.right == null)
                return;

            Node rightSubtree = node.right;
            node.right = rightSubtree.left;
            if (rightSubtree.left != null)
                rightSubtree.left.parent = node;
            rightSubtree.parent = node.parent;
            if (node.parent == null)
                root = rightSubtree;
            else if (node == node.parent.left)
                node.parent.left = rightSubtree;
            else
                node.parent.right = rightSubtree;
            rightSubtree.left = node;
            node.parent = rightSubtree;
        }

        protected void rightRotate(Node node)
        {
            if (node.left == null)
                return;

            Node rightSubtree = node.left;
            node.left = rightSubtree.right;
            if (rightSubtree.right != null)
                rightSubtree.right.parent = node;
            rightSubtree.parent = node.parent;
            if (node.parent == null)
                root = rightSubtree;
            else if (node == node.parent.right)
                node.parent.right = rightSubtree;
            else
                node.parent.left = rightSubtree;
            rightSubtree.right = node;
            node.parent = rightSubtree;
        }


        public override void setToRoot()
        {
            current = root;
        }

        public override bool hasRight()
        {
            return current.right != null;
        }

        public override void right()
        {
            current = current.right;
        }

        public override bool hasLeft()
        {
            return current.left != null;
        }

        public override void left()
        {
            current = current.left;
        }

        protected class Node
        {
            public Node left;
            public Node right;
            public Node parent;
            public Student data;
            public string color;
            public const string RED = "RED";
            public const string BLACK = "BLACK";

            public Node(Student data, Node parent)
            {
                this.data = data;
                this.setColorBlack();
                left = null;
                right = null;
                this.parent = parent;
            }

            public void setColorRed()
            {
                this.color = Node.RED;
            }

            public void setColorBlack()
            {
                this.color = Node.BLACK;
            }
        }
    }
}
