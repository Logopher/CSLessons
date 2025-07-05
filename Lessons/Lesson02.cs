namespace Lessons
{
    // "public" means that this class and its Main method can be accessed from other classes.
    public class Lesson02
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
            memory[2] = "baz";

            int ptr1 = 0; // Pointer to the first element
            int ptr2 = 2;

            memory[ptr1] = "qux"; // Change the first element

            // We can print our values.
            Console.WriteLine(memory[ptr1] + memory[ptr2]);

            ptr2 = 1;

            // If we print the values again, the second part of the output is different.
            Console.WriteLine(memory[ptr1] + memory[ptr2]);
        }
    }
}
