using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public class Lesson12
    {
        // If you don't specify an access modifier, it defaults to private.
        class Example
        {
            // Strings are immutable, meaning they cannot be changed after they are created.
            // A readonly field also cannot be assigned a different object, so it will always have
            // the same string that cannot be modified.
            // public readonly string text;

            // A readonly character array can be modified, but you cannot assign a new array to it.
            public readonly char[] text;

            public string Text
            {
                get { return new string(text); }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "Value cannot be null.");
                    }

                    // We can't reassign 'text', but we can modify its contents.
                    var temp = value.ToCharArray();

                    Debugger.Break();

                    temp.CopyTo(text, 0);

                    Debugger.Break();
                }
            }

            // A constant field is a compile-time constant, so it must be assigned at its declaration.
            public const string ConstantText = "bar";

            // Objects constructed at runtime cannot be constants, but you can get a similar effect with "static readonly".
            // This is an example of the singleton pattern, where only one instance of the class is created.
            // It's often called an anti-pattern, meaning it's a design that is generally discouraged.
            public static readonly Example Instance = new Example("baz");

            // This is an indexer, which allows you to access the object like an array.
            // It can be used to get or set values in the object.
            public char this[int index]
            {
                get
                {
                    if (index < 0 || index >= text.Length)
                    {
                        throw new IndexOutOfRangeException("Index is out of range.");
                    }

                    return text[index];
                }
                set
                {
                    text[index] = value;
                }
            }

            Example(string text)
            {
                this.text = text.ToCharArray();
            }
        }

        public static void Main()
        {
            Console.WriteLine(Example.ConstantText);

            // "var" is a keyword that allows the compiler to infer the type of the variable.
            var one = Example.Instance;

            Console.WriteLine(one.text);
            Console.WriteLine(one[1]);

            one[0] = 'x';

            Console.WriteLine(one.text);
            Console.WriteLine(one[1]);
        }
    }
}
