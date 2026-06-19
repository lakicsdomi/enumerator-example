namespace Enumerators
{
    // Static class for extension methods implementing standard algorithms
    public static class EnumeratorAlgorithms
    {
        // 1. Summation
        // Calculates the sum of integer elements
        public static int Sum(this IEnumerator<int> enumerator)
        {
            int sum = 0;
            enumerator.First();
            while (!enumerator.End())
            {
                sum += enumerator.Current();
                enumerator.Next();
            }
            return sum;
        }

        // 2. Counting
        // Counts the elements that satisfy a specific condition (predicate)
        public static int Count<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate)
        {
            int count = 0;
            enumerator.First();
            while (!enumerator.End())
            {
                if (predicate(enumerator.Current()))
                {
                    count++;
                }
                enumerator.Next();
            }
            return count;
        }

        // 3. Maximum Selection
        // Finds the maximum element in a collection of comparables
        public static T Max<T>(this IEnumerator<T> enumerator) where T : IComparable<T>
        {
            enumerator.First();
            if (enumerator.End())
            {
                throw new InvalidOperationException("Cannot find maximum: the collection is empty.");
            }

            T max = enumerator.Current(); // Assume the first element is the max
            enumerator.Next();

            while (!enumerator.End())
            {
                // CompareTo returns > 0 if the current element is greater than max
                if (enumerator.Current().CompareTo(max) > 0)
                {
                    max = enumerator.Current();
                }
                enumerator.Next();
            }
            return max;
        }

        // 4. Decision / Any
        // Checks if at least one element satisfies the condition
        public static bool Any<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate)
        {
            enumerator.First();
            while (!enumerator.End())
            {
                if (predicate(enumerator.Current()))
                {
                    return true; // Found a matching element, stop iterating immediately
                }
                enumerator.Next();
            }
            return false; // Reached the end without finding any match
        }

        // 5. Linear Search / TryFind
        // Tries to find the first element that satisfies the condition
        public static bool TryFind<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate, out T? result)
        {
            enumerator.First();
            while (!enumerator.End())
            {
                if (predicate(enumerator.Current()))
                {
                    result = enumerator.Current();
                    return true; // Found the element, output it and return true
                }
                enumerator.Next();
            }

            result = default; // Return the default value for type T (null for reference types, 0 for numeric types)
            return false; // Element not found
        }
    }
}