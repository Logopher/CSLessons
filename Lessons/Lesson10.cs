using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public class Lesson10
    {
        private class ExampleA
        {
            // A virtual method can be overridden in a derived class.
            public virtual void Foo()
            {
                Console.WriteLine("ExampleA.Foo() called.");
            }

            public void Bar()
            {
                Console.WriteLine("ExampleA.Bar() called.");
            }
        }

        private class ExampleB : ExampleA
        {
            // This is a new version of the virtual Foo() method.
            public override void Foo()
            {
                Console.WriteLine("ExampleB.Foo() called.");

                // If we don't do this, ExampleA.Foo() won't run.
                base.Foo();
            }

            // This is a new method named Bar(), no relation to ExampleA.Bar().
            // It hides the base class's Bar() method.
            // "new" can also hide a virtual method, but you would rarely want that.
            public new void Bar()
            {
                Console.WriteLine("ExampleB.Bar() called.");

                base.Bar();
            }
        }

        public static void Main()
        {
            ExampleA one = new ExampleA();
            ExampleB two = new ExampleB();
            ExampleA three = two; // Upcasting
            ExampleB four = (ExampleB)three; // Downcasting
            // four = (ExampleB)one; // This will throw an InvalidCastException at runtime.

            one.Foo();
            one.Bar();

            Console.WriteLine();

            two.Foo();
            two.Bar();

            Console.WriteLine();

            three.Foo();
            three.Bar();

            // This is the same as two.
            /*
            Console.WriteLine();

            four.Foo();
            four.Bar();
            // I like to comment out the closing part of the block comment.
            //*/
        }
    }
}
