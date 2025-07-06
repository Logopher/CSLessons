using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter1
{
    // A static class is only allowed to have static members.
    public static class Lesson08
    {
        private class Example
        {
            public Example(string text)
            {
                Console.WriteLine("Example class constructor called with \"" + text + "\".");

                // This assigns the property, below, not the field.
                // Because the property's name is different from the parameter's, we don't need 'this.' here.
                Text = text;
            }

            // Now the field isn't public, so Main can't access it.
            // Because its purpose is to hold the value of the property, it is a "backing field".
            private string text;

            public string Text
            {
                get { return text; }
                set { text = value; }
            }
        }

        public static void Main()
        {
            Example one = new Example("foo");

            Console.WriteLine(one.Text);

            one.Text = "bar";

            Console.WriteLine(one.Text);
        }
    }
}
