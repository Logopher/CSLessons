using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter1
{
    public class Lesson07
    {
        private class Example
        {
            public string text;

            // This constructor can only be called from within the class.
            private Example(string text)
            {
                Console.WriteLine("Example class constructor called with \"" + text + "\".");

                this.text = text;
            }

            // This is a factory method, which is a static method that creates an instance of the class.
            // Since the constructor isn't public, Main will have to use this to get an Example.
            // Factory methods are useful because constructors have some restrictions, which we'll cover later.
            public static Example Create(string text)
            {
                return new Example(text);
            }

            // This method returns the reverse of 'text'.
            // It is an instance method, so it can be called on an instance of the class.
            // It returns string, which means its last operation must be to return a string.
            public string GetReversedText()
            {
                char[] charArray = text.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }

            // This method reverses 'text'.
            // It is an instance method, so it can be called on an instance of the class.
            // It returns void, meaning it has no return value. 'return' can still be used
            // to send execution back to the caller, but it can't have a value.
            public void ReverseText()
            {
                text = GetReversedText();
            }

            public void DoStuff()
            {
                throw new Exception("This is an example of an exception being thrown.");
            }
        }

        public static void Main()
        {
            Example one = Example.Create("foo");

            Console.WriteLine(one.text);

            one.ReverseText();

            Console.WriteLine(one.text);

            try
            {
                one.DoStuff();
            }
            catch (Exception ex)
            {
                Debugger.Break();

                // This will catch any exception thrown by DoStuff() and print its message.
                Console.WriteLine("An exception was caught: " + ex.Message);
            }
        }
    }
}
