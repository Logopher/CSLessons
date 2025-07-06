using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter1
{
    public class Lesson04
    {
        // This is another class, in addition to Lesson04.
        // It's inside Lesson03, and because it's not "public",
        // it can only be accessed from within Lesson03.
        // That's handy in this case because I want "Example"
        // classes in other lessons.
        private class Example
        {
            public Example(string text)
            {
                // This is the constructor of the Example class.
                // It is called when an instance of Example is created.
                // "+" here is string concatenation, which means it joins two strings together.
                Console.WriteLine("Example class constructor called with \"" + text + "\".");
                // Place your caret on the line above and press F9 to set a breakpoint.
                // You can also do this by clicking the gutter to the left of the line numbers.

                // The caller passed us a string, and we're going to keep it.
                this.text = text;
            }

            // This is a *field*, not a property.
            // You probably encountered properties in Python. C# fields are basically the same.
            // C# properties come later.
            public string text;
        }

        public static void Main()
        {
            Example one = new Example("foo");
            Example two = new Example("bar");
            Example three = new Example("baz");

            // This line prints the Text field of the first Example to the console.
            Console.WriteLine(one.text);
            // Put your caret on "text" and press F12 to go to the definition of the field.

            Example ptr1 = one;
            Example ptr2 = three;

            // We can print our values.
            Console.WriteLine(ptr1.text + ptr2.text);

            ptr2 = two;

            // If we print the values again, the second part of the output is different.
            Console.WriteLine(ptr1.text + ptr2.text);

            // The exclamation point after `null` is a null-forgiving operator, which tells the compiler
            // not to warn about nulls. Generally, you should avoid using it unless you're sure the value won't be null.
            ptr2 = null!;

            // This will throw a NullReferenceException.
            Console.WriteLine(ptr1.text + ptr2.text);
        }
    }
}
