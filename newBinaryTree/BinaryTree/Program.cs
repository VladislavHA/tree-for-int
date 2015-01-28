using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<double>(10.0f);
            Console.WriteLine(tree.Print());
            tree.AddLeft(5);
            Console.WriteLine(tree.Print());
            tree.AddRight(15);
            Console.WriteLine(tree.Print());
            tree.FindNode(new Tree<double>(5)).AddLeft(2);
            Console.WriteLine(tree.Print());
            tree.FindNode(new Tree<double>(5)).AddRight(7);
            Console.WriteLine(tree.Print());
            tree.Delete(new Tree<double>(7));
            Console.WriteLine(tree.Print());
            var a = tree.FindNode(new Tree<double>(2));
            Console.WriteLine(a.Print());
            


            Console.ReadKey();
        }
    }
}
