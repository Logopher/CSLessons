using System.Diagnostics;

namespace Lessons
{
    // "public" means that this class and its Main method can be accessed from other classes.
    public class Lesson01
    {
        // Main is a static method, which means it can be called without creating an instance of the class.
        public static void Main()
        {
            // string[] is read "string array".
            // This is an array of strings;
            // the array is named "memory" and can hold 3 strings
            string[] memory = new string[3];

            memory[0] = "foo";
            memory[1] = "bar";

            // This will pause the debugger.
            // You can inspect variables and step through the code line by line.
            // You can also use the Immediate window to run arbitrary code while execution is paused.
            Debugger.Break();

            memory[2] = "baz";

            // This line would cause a compile error because
            // it tries to access an index that is out of bounds.
            // The compiler catches a lot of simple mistakes like this.
            //memory[3] = "qux";

            // This line prints the first element of the array to the console.
            // WriteLine is a static method of the Console class, which is what allows us to call
            // it without an instance of Console.
            Console.WriteLine(memory[0]);
            Console.WriteLine(memory[1]); // And we keep printing.
            Console.WriteLine(memory[2]);

            // This line prints the length of the array to the console.
            Console.WriteLine(memory.Length);

            // We can use that Length to print the whole array without knowing,
            // *when we write the code*, how big the array is.
            {
                int i = 0;

                while (i < memory.Length)
                {
                    Console.WriteLine(memory[i]);

                    i++;
                }
            }

            for (int i = 0; i < memory.Length; i++)
            {
                Console.WriteLine(memory[i]);
            }
        }
    }
}
