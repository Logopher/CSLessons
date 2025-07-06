using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter1
{
    public class Lesson05
    {
        // This is substantially the same Example class as in Lesson04.
        private class Example
        {
            public Example(string text)
            {
                Console.WriteLine("Example class constructor called with \"" + text + "\".");

                this.text = text;
            }

            public string text;
        }

        // A struct is fundamentally different from a class.
        // I'll explain further below.
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
            Example one = new Example("foo");
            Example two = one;

            AnotherExample three = new AnotherExample("bar");
            AnotherExample four = three;

            Console.WriteLine(one.text + two.text);
            Console.WriteLine(three.text + four.text);
            // Put your caret on "text" and press F2 to rename the field in all instances.

            // Now let's change the text of the second Example and the second AnotherExample.
            two.text = "baz";
            four.text = "qux";

            Console.WriteLine(one.text + two.text);
            Console.WriteLine(three.text + four.text);

            // This will assign null to five. The default value of a reference type is null.
            Example five = default!;

            // The '?' marks six as nullable.
            // As a reference type, .Net will already allow it to be null,
            // but newer versions of C# have a setting to warn when a reference-type
            // variable might be set to null, unless it's marked nullable.
            // See TonyLessons.csproj and find the setting: <Nullable>enable</Nullable>
            Example? six = null;

            // This will also assign null to six. The only difference from five is that we don't need
            // an exclamation point to avoid warnings.
            six = default;

            // But then we need it when assigning the same value to five.
            five = six!;

            // This will produce an instance of AnotherExample with default values ('text' will be null).
            // Actually assigning null, or any value that might be null, to a struct variable is not allowed.
            AnotherExample seven = default;

            // This will assign null to eight. The default value of a nullable value type is null.
            AnotherExample? eight = default;

            // The key difference between classes and structs is that classes are reference types, while structs are value types.
            // This means that when you assign a class to a variable, you're assigning a reference to the object in memory, not the object itself.
            // When you assign a struct to a variable, you're copying the entire value of the struct.
            // So when we assigned `two` to `one`, they both pointed to the same object in memory.
            // When we assigned `four` to `three`, they were two separate copies of the struct, so changing one didn't affect the other.
            // If you want to see this in action, try changing the text of `one` and `three` and printing them again.

            // Other than this difference in copy behavior, classes and structs are very similar.
            // Because an entire struct is copied, usually large types are classes.
            // Further reading: https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct
        }
    }
}
