using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public static class Lesson14
    {
        // Click the down arrow to the left to collapse this class definition.
        // It's the same as in the previous lesson.
        class ExampleEnumerator : IEnumerator
        {
            private readonly object?[] _collection;
            private int _cursor;

            public ExampleEnumerator(object?[] collection)
            {
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

        // IEnumerable is an interface that allows a class to be enumerated (iterated over) using a foreach loop or an enumerator.
        class ExampleEnumerable : IEnumerable
        {
            private readonly object?[] _collection;

            public ExampleEnumerable(object?[] collection)
            {
                _collection = collection ?? throw new ArgumentNullException(nameof(collection));
            }

            public IEnumerator GetEnumerator()
            {
                return new ExampleEnumerator(_collection);
            }
        }

        public static void Main()
        {
            // The brackets form a "collection initializer," which just means Add()
            // is called for each item immediately after the collection (the array) is constructed.
            var memory = new string?[]
            {
                "foo",
                "bar",
                null,
                "baz",
            };

            var enumerable = new ExampleEnumerable(memory);

            // This is a foreach loop, which is a syntactic sugar for using an enumerator.
            foreach (var item in enumerable)
            {
                // The 'item' variable is of type object, so we need to cast it to string.
                // This is safe because we know the collection contains strings.
                // The compiler doesn't warn that 'item' might be null, but in fact
                // the third element is null.
                // Nullable reference types are only an editing aid, not a runtime check.
                Console.WriteLine((string)item);
            }

            // And look what else we can do.
            foreach (var surprise in Bonus())
            {
                // Actually WriteLine can take any type of value.
                Console.WriteLine(surprise);
            }
        }

        static IEnumerable Bonus()
        {
            // This is a simple example of an IEnumerable that returns a sequence of integers.
            for (int i = 0; i < 10; i++)
            {
                // "yield return" is a special keyword that allows you to
                // return a sequence of values from an iterator method.
                yield return i;
            }
        }
    }
}
