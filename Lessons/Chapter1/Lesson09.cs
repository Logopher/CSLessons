using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter1
{
    public static class Lesson09
    {
        public static void Main()
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Random number: " + random.Next(1, 101));
            }

            Console.ReadLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);

            // Use ideas presented so far to build a game where the user reapeatedly guesses at a random number.
        }
    }
}
