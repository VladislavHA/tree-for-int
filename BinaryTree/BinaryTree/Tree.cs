using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree
    {
        double value;
        Tree left;
        Tree right;
        Tree Parent;

        public Tree(double value)
        {
            this.value = value;
        }

        public void AddValue(double value) //  из корневого узла (сверяем с текущим значением узла) 
        {
            if (value < this.value)  
            {
                if (this.left == null)
                {
                    this.left = new Tree(value);
                }
                else
                {
                    this.left.AddValue(value);
                }
            }
            if (value > this.value)
            {
                if (this.right == null)
                {
                    this.right = new Tree(value);
                }
                else
                {
                    this.right.AddValue(value);
                }
            }
        }

        public Tree FindNode(double value)
        {

            if (this.value < value)
            {
                return left.FindNode(value);
                
            }
            else if (this.value > value)
            {
                return right.FindNode(value);
            }
            else
            {
                return this;
            }

        }

        private Tree FindMin()
        {
            var currentNode = this;
            while(currentNode.left != null) //???  while current_node.left_child:
       // current_node = current_node.left_child
            {
                currentNode = currentNode.left;
            }
            return currentNode;
        }

        private void replaceNodeInParent(Tree newValue) 
        {
            if (this.Parent !=null)
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

        public void Delete( double value)
        {
            if (value < this.value)
            {
                this.left.Delete(value); 
            }
            else if (value > this.value)
            {
                this.right.Delete(value); 
            }
            else
            {
                if (this.left != null &&  this.right != null)
                {
                    var successor = this.right.FindMin();
                    this.value = successor.value;
                    successor.Delete(successor.value); 

                }
                else if(this.left != null)
                {
                    this.replaceNodeInParent(this.left); 
                }
                else if (this.right != null)
                {
                    this.replaceNodeInParent(this.right); 
                }
                else
                {
                    this.replaceNodeInParent(null); // self.replace_node_in_parent(None)
                }


            }


        }


        
           

        }
        



    }
}
