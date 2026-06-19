using System;
using System.Collections.Generic;

namespace Enumerators
{
    /// <summary>
    /// Enumerator class that acts as a facade for different types of enumerators.
    /// </summary>
    public class Enumerator<T>
    {
        private string EnumeratorType { get; set; }
        private IEnumerator<T>? enumerator;

        public Enumerator(object collection)
        {
            // Using modern C# switch expression for clean pattern matching.
            // ValueTuple types are explicitly stated since 'collection' is an object.
            (enumerator, EnumeratorType) = collection switch
            {
                List<T> list => (new ListEnumerator<T>(list), "List"),
                T[] array => (new ArrayEnumerator<T>(array), "Array"),
                T[,] matrix => (new MatrixEnumerator<T>(matrix), "Matrix"),
                HashSet<T> set => (new SetEnumerator<T>(set), "Set"),
                Stack<T> stack => (new StackEnumerator<T>(stack), "Stack"),
                Queue<T> queue => (new QueueEnumerator<T>(queue), "Queue"),
                Dictionary<T, int> bag => (new BagEnumerator<T>(bag), "Bag"),

                // Explicitly matching ValueTuple for graph
                ValueTuple<Dictionary<T, List<T>>, T> graphData => (new GraphEnumerator<T>(graphData.Item1, graphData.Item2), "Graph"),

                // Explicitly matching ValueTuple for interval
                ValueTuple<int, int> interval when typeof(T) == typeof(int) => ((IEnumerator<T>)(object)new IntervalEnumerator(interval.Item1, interval.Item2), "Interval"),

                // Pattern matching with condition (when clause)
                string fileName when typeof(T) == typeof(string) => ((IEnumerator<T>)(object)new FileEnumerator(fileName), "File"),
                int maxCount when typeof(T) == typeof(int) => ((IEnumerator<T>)(object)new FibonacciEnumerator(maxCount), "Fibonacci"),

                // Default fallback (equivalent to the 'else' block)
                _ => throw new ArgumentException("Unsupported type or generic type mismatch.")
            };
        }

        public void ProcessCollection(Action<T> action)
        {
            Console.WriteLine($"\nProcessing collection of type: {EnumeratorType}");

            if (enumerator != null)
            {
                enumerator.First();
                while (!enumerator.End())
                {
                    action(enumerator.Current());
                    enumerator.Next();
                }

                // Clean up if the enumerator implements IDisposable
                if (enumerator is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}