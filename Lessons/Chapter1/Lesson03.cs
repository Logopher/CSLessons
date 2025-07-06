using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter1
{
    public class Lesson03
    {
        public static void Main()
        {
            // string[] is read "string array".
            // This is an array of strings;
            // the array is named "memory" and can hold 3 strings
            string[] memory = new string[3];

            memory[0] = "foo";
            memory[1] = "bar";

            int ptr1 = 0; // Pointer to the first element
            int ptr2 = 1;

            ptr1 = ptr2;

            // We can print our values.
            Console.WriteLine(memory[ptr1] + memory[ptr2]);

            memory[ptr1] = "qux";

            // If we print the values again, the second part of the output is different.
            Console.WriteLine(memory[ptr1] + memory[ptr2]);
        }
    }
}
