using Enumerators;

namespace EnumeratorsExample
{
    internal class Program
    {
        #region Enumerator Methods

        // A single, polymorphic method replacing all the specific EnumerateX methods.
        // This demonstrates the power of the IEnumerator<T> interface.
        public static void TestEnumerator<T>(Enumerators.IEnumerator<T> enumerator, string name)
        {
            Console.WriteLine($"--- {name} Enumerator Example ---");

            enumerator.First();  // Initialize with First()
            while (!enumerator.End())  // Loop until End() returns true
            {
                Console.WriteLine(enumerator.Current());  // Process current element
                enumerator.Next();  // Move to next element
            }

            // Clean up if it's a file or other disposable resource
            if (enumerator is IDisposable disposable)
            {
                disposable.Dispose();
            }

            Console.WriteLine($"Finished enumerating the {name.ToLower()}.\n");
        }

        #endregion

        static void Main(string[] args)
        {
            // --- Setup Basic Collections ---
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] strings = { "apple", "banana", "cherry" };
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 } };
            string filename = "example.txt";
            if (!System.IO.File.Exists(filename))
            {
                System.IO.File.WriteAllText(filename, "This\nis\na\nfile\nenumerator\nexample");
            }
            List<string> list = new List<string> { "first", "second", "third" };

            // --- Setup New Collections ---
            HashSet<int> set = new HashSet<int> { 100, 200, 300 };

            Stack<string> stack = new Stack<string>();
            stack.Push("Bottom");
            stack.Push("Middle");
            stack.Push("Top");

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("First in line");
            queue.Enqueue("Second in line");
            queue.Enqueue("Third in line");

            Dictionary<string, int> bag = new Dictionary<string, int>
            {
                { "Apple", 2 },
                { "Banana", 3 }
            };

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>
            {
                { "A", new List<string> { "B", "C" } },
                { "B", new List<string> { "D" } },
                { "C", new List<string> { "D" } },
                { "D", new List<string>() }
            };

            // --- Testing Individual Methods (Polymorphic Approach) ---
            Console.WriteLine("=== Basic Enumerators ===\n");
            TestEnumerator(new ArrayEnumerator<int>(numbers), "Array");
            TestEnumerator(new IntervalEnumerator(1, 3), "Interval");
            TestEnumerator(new MatrixEnumerator<int>(matrix, true), "Matrix");
            TestEnumerator(new FileEnumerator(filename), "File");
            TestEnumerator(new ListEnumerator<string>(list), "List");

            Console.WriteLine("=== New Concept Enumerators ===\n");
            TestEnumerator(new SetEnumerator<int>(set), "Set");
            TestEnumerator(new StackEnumerator<string>(stack), "Stack (LIFO)");
            TestEnumerator(new QueueEnumerator<string>(queue), "Queue (FIFO)");
            TestEnumerator(new BagEnumerator<string>(bag), "Bag (Multiplicity)");
            TestEnumerator(new GraphEnumerator<string>(graph, "A"), "Graph (BFS from A)");
            TestEnumerator(new FibonacciEnumerator(5), "Fibonacci (First 5 numbers)");

            #region Universal Enumerator

            Console.WriteLine("=== Universal Enumerator Examples ===\n");

            Enumerator<int> arrayEnumerator = new Enumerator<int>(numbers);
            arrayEnumerator.ProcessCollection(item => Console.WriteLine(item));

            Enumerator<string> fileEnumerator = new Enumerator<string>(filename);
            fileEnumerator.ProcessCollection(item => Console.WriteLine(item));

            Enumerator<int> setEnumerator = new Enumerator<int>(set);
            setEnumerator.ProcessCollection(item => Console.WriteLine($"Set element: {item}"));

            Enumerator<string> stackEnumerator = new Enumerator<string>(stack);
            stackEnumerator.ProcessCollection(item => Console.WriteLine($"Stack element: {item}"));

            Enumerator<string> queueEnumerator = new Enumerator<string>(queue);
            queueEnumerator.ProcessCollection(item => Console.WriteLine($"Queue element: {item}"));

            Enumerator<string> bagEnumerator = new Enumerator<string>(bag);
            bagEnumerator.ProcessCollection(item => Console.WriteLine($"Bag item: {item}"));

            // Pass the graph and the start node as a ValueTuple
            Enumerator<string> graphEnumerator = new Enumerator<string>((graph, "A"));
            graphEnumerator.ProcessCollection(item => Console.WriteLine($"Graph node: {item}"));

            // Pass the amount of numbers to generate
            Enumerator<int> fibonacciEnumerator = new Enumerator<int>(7);
            fibonacciEnumerator.ProcessCollection(item => Console.WriteLine($"Fibonacci number: {item}"));

            #endregion


            #region Algorithm Testing

            Console.WriteLine("=== Standard Programming Algorithms ===\n");

            int[] algoNumbers = { 4, 1, 9, -3, 7, 2 };
            Enumerators.IEnumerator<int> algoEnumerator = new ArrayEnumerator<int>(algoNumbers);

            // 1. SUM
            int totalSum = algoEnumerator.Sum();
            Console.WriteLine($"Sum of elements: {totalSum}");

            // 2. COUNT, how many elements are positive numbers
            int positiveCount = algoEnumerator.Count(x => x > 0);
            Console.WriteLine($"Number of positive elements: {positiveCount}");

            // 3. MAX
            int maxValue = algoEnumerator.Max();
            Console.WriteLine($"Maximum element: {maxValue}");

            // 4. CHECK if there are any negative numbers
            bool hasNegative = algoEnumerator.Any(x => x < 0);
            Console.WriteLine($"Contains negative numbers: {hasNegative}");

            // 5. SEARCH for the first element greater than 5
            if (algoEnumerator.TryFind(x => x > 5, out int foundValue))
            {
                Console.WriteLine($"First element greater than 5: {foundValue}");
            }
            else
            {
                Console.WriteLine("No element greater than 5 was found.");
            }

            /*
             * EXERCISE:
             * Do it yourself:
             * 1. Try the algorithms with a FileEnumerator, for example, to check if a file contains a specific string or to count lines.
             * 2. Try the algorithms with the other enumerators. 
             */

            #endregion
        }
    }
}
