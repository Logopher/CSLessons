using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public static class Lesson09
    {
        // This is an interface, which is very different from both classes and structs.
        // Interfaces are named 1) with an 'I' prefix, and 2) to describe some specific
        // functionality of a type.
        // Classes and structs that implement an interface must provide the
        // functionality described by the interface.
        // A class or struct can implement any number of interfaces.
        // An interface can extend any number of interfaces.
        private interface IHasText
        {
            // Interfaces can have properties and methods, but not fields or constructors.
            // Interface members are public and abstract.
            // Abstract means they have no implementation.
            string Text { get; set; }
        }

        private class Example : IHasText
        {
            public Example(string text)
            {
                Console.WriteLine("Example class constructor called with \"" + text + "\".");

                Text = text;
            }

            // This property is "auto-implemented," meaning
            // its backing field and implementation are hidden.
            public string Text { get; set; }
        }

        // Structs can implement interfaces, but they can't extend classes.
        // Structs cannot be extended by anything, either.
        private struct AnotherExample : IHasText
        {
            public AnotherExample(string text)
            {
                Console.WriteLine("AnotherExample struct constructor called with \"" + text + "\".");

                Text = text;
            }

            public string Text { get; set; }
        }

        public static void Main()
        {
            IHasText one = new Example("foo");
            IHasText two = one;
            IHasText three = new AnotherExample("bar");
            IHasText four = three;

            Console.WriteLine(one.Text + two.Text);
            Console.WriteLine(three.Text + four.Text);

            one.Text = "baz";
            three.Text = "qux";

            Console.WriteLine(one.Text + two.Text);
            Console.WriteLine(three.Text + four.Text);

            two.Text = "quux";
            four.Text = "corge";

            Console.WriteLine(one.Text + two.Text);
            Console.WriteLine(three.Text + four.Text);
        }
    }
}
