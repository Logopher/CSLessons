using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter2
{
    public class Lesson08
    {
        class Node
        {
            public string Name { get; set; }

            /// <summary>
            /// This property defaults to an empty list; the type is inferred from the property type.
            /// 
            /// Also, this is an XML documentation comment. It lets us
            /// do cool things like <see cref="IEnumerable{T}"/>.
            /// That interface is the generic version of the IEnumerable
            /// you already saw.
            /// </summary>
            public List<Node> Children { get; set; } = [];

            public Node(string name)
            {
                Name = name;
            }
        }

        static Node _rootNode = new("Root")
        {
            Children =
            [
                new("Child 1")
                {
                    Children =
                    [
                        new("Grandchild 1"),
                        new("Grandchild 2"),
                    ]
                },
                new("Child 2")
                {
                    Children =
                    [
                        new("Grandchild 3"),
                        new("Grandchild 4"),
                    ]
                },
            ]
        };

        // This method recursively prints the name of every node.
        static void Print(Node node, string indent = "")
        {
            Console.WriteLine(indent + node.Name);

            foreach (var child in node.Children)
            {
                Print(child, indent + "  ");
            }
        }

        // This method collects the entire chain of nodes from the root to each node,
        // then does whatever the caller wants with that chain.
        static void ForEach(IList<Node> chain, Action<IList<Node>> action)
        {
            action(chain);

            var node = chain.Last();

            // This is a "foreach" loop; it iterates over each child of the node.
            foreach (var child in node.Children)
            {
                // Recursively call ForEach on each child.
                ForEach(
                    chain.Concat([child]).ToList(),
                    action);
            }
        }

        // This is a convenience method that allows the caller to pass just a single node.
        static void ForEach(Node node, Action<IList<Node>> action)
        {
            // Create a list to hold the current chain of nodes.
            var chain = new List<Node> { node };

            ForEach(chain, action);
        }

        public static void Main()
        {
            Print(_rootNode);

            ForEach(_rootNode, chain =>
            {
                Console.WriteLine(string.Join(
                    " > ",
                    chain.Select(node => node.Name)));
            });
        }
    }
}
