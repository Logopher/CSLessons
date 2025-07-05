using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public class Lesson13
    {
        // IEnumerator is an interface that enables iteration (like the earlier for loop) over a collection.
        class ExampleEnumerator : IEnumerator
        {
            private readonly object[] _collection;
            private int _cursor;

            public ExampleEnumerator(object[] collection)
            {
                // The null-coalescing operator can throw an exception in the null case.
                _collection = collection ?? throw new ArgumentNullException(nameof(collection));

                Reset();
            }

            public object? Current
            {
                get
                {
                    try
                    {
                        return _collection[_cursor];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        // This suppresses VS's warning that ex is declared and never used.
                        // I like having exception objects available for the debugger.
                        ex.ToString();

                        if (_cursor == -1)
                        {
                            // If the cursor is -1, it means MoveNext() has not been called yet.
                            throw new InvalidOperationException("Enumeration has not started. Call MoveNext() first.", ex);
                        }
                        else
                        {
                            // If the cursor is out of range, it means MoveNext() has been called too many times.
                            throw new InvalidOperationException("This enumerator has completed. Call Reset() if you want to start at the beginning.", ex);
                        }
                    }
                }
            }

            public bool MoveNext()
            {
                _cursor++;

                return _cursor < _collection.Length;
            }

            public void Reset()
            {
                _cursor = -1;
            }
        }

        public static void Main()
        {
            // The brackets form a "collection initializer," which just means Add()
            // is called for each item immediately after the collection (the array) is constructed.
            var memory = new string[]
            {
                "foo",
                "bar",
                "baz"
            };

            var enumerator = new ExampleEnumerator(memory);

            while (enumerator.MoveNext())
            {
                // This is the same as enumerator.Current, but it uses the "as" operator
                // to cast the object to a string. If it fails, it will return null.
                string? item = enumerator.Current as string;

                // Alternatively, you can cast to a string,
                // which would throw InvalidCastException if Current were not null or a string.
                //string? item = (string?)enumerator.Current;

                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }

            // Next lesson will show how to enable this:
            foreach (var s in memory)
            {
                Console.WriteLine(s);
            }
        }
    }
}
