using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Chapter2
{
    public static class Lesson15
    {
        // This is a generic class. T is a "type parameter" that can be
        // assigned as any type when an instance of the class is created.
        class Example<T>
            where T : INumber<T> // This "constraint" means T must implement the INumber interface.
            // This class can do math with any number type, because .Net's numbers all implement INumber.
        {
            public T A { get; set; }
            public T B { get; set; }

            public T Add() => A + B;

            public T Subtract() => A - B;

            public T Multiply() => A * B;

            public T Divide() => A / B;
        }

        public static void Main()
        {
            // The brackets form an "object initializer"; all assignments inside will modify the new object.
            var one = new Example<int>
            {
                A = 1,
                B = 2,
            };

            var sum = one.Add(); // Returns 3.
        }
    }
}
