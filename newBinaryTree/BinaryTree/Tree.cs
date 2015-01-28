using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree<T> where T : IComparable<T>, IEquatable<T>
    {
        T value;
        Tree<T> left;
        Tree<T> right;
        Tree<T> Parent;

        public Tree(T value)
        {
            this.value = value;
        }   

        public void AddLeft(T value)
        {
            var node = new Tree<T>(value);
            AddLeft(node);
        }

        public void AddLeft(Tree<T> node)
        {
            this.left = node;
            node.Parent = this;
        }

        public void AddRight(T value)
        {
            var node = new Tree<T>(value);
            AddRight(node);
        }

        public void AddRight(Tree<T> node)
        {
            this.right = node;
            node.Parent = this;
        }
        
        public Tree<T> FindNode(Tree<T> node)
        {
            if (this.value.Equals(node.value))
            {
                return this;
            }

            Tree<T> result = null;

            if (node.left != null)
            {
                result = FindNode(node.left);
            }

            if (result != null)
            {
                return result;
            }

            if (node.right != null)
            {
                result = FindNode(node.right);
            }

            return result;
        }

        private Tree<T> FindMin()
        {
            var currentNode = this;
            while (currentNode.left != null)
            {
                currentNode = currentNode.left;
            }
            return currentNode;
        }

        private void replaceNodeInParent(Tree<T> newValue)
        {
            if (this.Parent != null)
            {
                if (this == this.Parent.left)
                {
                    this.Parent.left = newValue;
                }
                else
                {
                    this.Parent.right = newValue;
                }
            }
            if (newValue != null)
            {
                newValue.Parent = this.Parent;
            }

        }

        public void Delete(Tree<T> value)
        {
            var toDelete = FindNode(value);

            if (toDelete == null)
            {
                throw new Exception("Node not found.");
            }

            var parent = toDelete.Parent;
            if (parent.left.Equals(toDelete))
            {
                parent.left = null;
            }
            else
            {
                parent.right = null;
            }
        }

        //public override string ToString()
        //{
        //    return FromLeft(this);
        //}

        private string FromLeft(Tree<T> node)
        {
            var result = "";
            if (node.left != null)
            {
                result = FromLeft(node.left);
            }

            if (node.right != null)
            {
                result = string.Format("{0} {1}", result, FromLeft(node.right));                
            }

            return string.Format("{0} {1}", result, node.value);
        }

        public string Print()
        {
            return FromLeft(this);
        }
    }
}