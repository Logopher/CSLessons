using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public class Lesson11
    {
        private interface IHasText
        {
            string Text { get; }

            string MoreText { get; }

            string YetMoreText { get; set; }
        }

        // An abstract class can have both abstract and non-abstract (concrete) members.
        // It is obligated to implement any interfaces it declares, but its implementation can be abstract.
        // If an abstract class extends another abstract class, it doesn't need to repeat the base class's members.
        private abstract class AbstractExample : IHasText
        {
            // This is an abstract property; abstract members must be implemented by derived classes.
            // Abstract members are virtual; derived classes must "override" them.
            public abstract string Text { get; set; }

            public abstract string MoreText { get; }

            public string YetMoreText
            {
                // Expression bodies are equivalent to block bodies, except they only allow a single expression.
                // Methods and constructors can have expression bodies, too.
                // If the method or property accessor (get) returns a type,
                // the expression must also return that type.
                // If the method or property accessor (set) does not return a type, or if it's a constructor,
                // the expression has no restrictions on its return type.
                get => "This is a concrete property in an abstract class.";
                set => Console.WriteLine("Setting YetMoreText to \"" + value + "\".");
            }
        }

        private class ExampleA : AbstractExample
        {
            public override string Text { get; set; }

            // Unlike an interface, properties declared in an abstract class
            // cannot be expanded in derived classes.
            public override string MoreText { get; /*set;*/ }
        }

        private class ExampleB : AbstractExample
        {
            public override string Text { get; set; }

            // An expression body for an entire property is always read-only (only has a getter).
            public override string MoreText => "This is a read-only property in a derived class.";
        }

        public static void Main()
        {
            // ExampleA and ExampleB are the only types of these four that can be instantiated.
            // We call them a concrete classes or concrete types.
            // It's far more common to call a type concrete than a property or method.
            ExampleA one = new ExampleA();
            ExampleB two = new ExampleB();

            one.Text = "foo";
            // one.MoreText = "bar"; // This will not compile, since MoreText is read-only.
            one.YetMoreText = "baz";
            two.Text = "qux";
            // two.MoreText = "quux";
            two.YetMoreText = "corge";

            Console.WriteLine(one.Text);
            Console.WriteLine(one.MoreText);
            Console.WriteLine(one.YetMoreText);

            Console.WriteLine(two.Text);
            Console.WriteLine(two.MoreText);
            Console.WriteLine(two.YetMoreText);
        }
    }
}
