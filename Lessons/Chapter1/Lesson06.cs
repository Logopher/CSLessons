using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter1
{
    // Lesson05 got too long. This was trimmed off of it.
    public class Lesson06
    {
        private class Example
        {
            public Example(string text)
            {
                Console.WriteLine("Example class constructor called with \"" + text + "\".");

                this.text = text;
            }

            public string text;
        }

        private struct AnotherExample
        {
            public AnotherExample(string text)
            {
                Console.WriteLine("AnotherExample struct constructor called with \"" + text + "\".");

                this.text = text;
            }

            public string text;
        }

        public static void Main()
        {
            // five has no value. If we try to use it, we'll get an compile error.
            // The compiler must be able to guarantee that five has a value (even null) before we can use it.
            Example five;
            Example? six = null;

            // We can make sure that a non-nullable variable gets a valid value.
            if (six == null)
            {
                five = new Example("default value");
            }
            else
            {
                // six is not null here, and does not require the exclamation point.
                five = six;
            }

            // This is the ternary operator (it means three-part),
            // an abbreviated way to do the same thing as above.
            five = six == null
                ? new Example("default value")
                : six;

            // This is the null-coalescing operator, which is even more abbreviated.
            five = six ?? new Example("default value");
        }
    }
}
