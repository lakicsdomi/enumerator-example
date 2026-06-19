namespace Enumerators
{
    /// <summary>
    /// Static class for extension methods implementing standard programming theorems for enumerators.
    /// </summary>
    public static class EnumeratorAlgorithms
    {
        /// <summary>
        /// Calculates the sum of the elements after applying a processing function.
        /// </summary>
        /// <param name="enumerator">The enumerator traversing the collection.</param>
        /// <param name="f">The function to apply to each element before adding it to the sum.</param>
        /// <returns>The total sum of the processed elements.</returns>
        public static int Sum(this IEnumerator<int> enumerator, Func<int, int> f)
        {
            int s = 0;
            enumerator.First();
            while (!enumerator.End())
            {
                s = s + f(enumerator.Current());
                enumerator.Next();
            }
            return s;
        }

        /// <summary>
        /// Counts the elements that satisfy a specific condition (predicate).
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="enumerator">The enumerator traversing the collection.</param>
        /// <param name="predicate">The condition that elements must satisfy to be counted.</param>
        /// <returns>The total number of elements matching the predicate.</returns>
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

        /// <summary>
        /// Finds both the maximum value and the corresponding element using an evaluator function.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <typeparam name="TResult">The type of the evaluated value to compare.</typeparam>
        /// <param name="enumerator">The enumerator traversing the collection.</param>
        /// <param name="f">The function to evaluate elements for comparison.</param>
        /// <returns>A tuple containing the maximum evaluated value and the element itself.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the collection is empty.</exception>
        public static (TResult maxValue, T element) Max<T, TResult>(this IEnumerator<T> enumerator, Func<T, TResult> f)
            where TResult : IComparable<TResult>
        {
            enumerator.First();

            if (enumerator.End())
            {
                throw new InvalidOperationException("Cannot find maximum: the collection is empty.");
            }

            T elem = enumerator.Current();
            TResult max = f(elem);
            enumerator.Next();

            while (!enumerator.End())
            {
                TResult currentVal = f(enumerator.Current());
                if (currentVal.CompareTo(max) > 0)
                {
                    elem = enumerator.Current();
                    max = f(elem);
                }
                enumerator.Next();
            }

            return (max, elem);
        }

        /// <summary>
        /// Finds the maximum element in a collection of comparable elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="enumerator">The enumerator traversing the collection.</param>
        /// <returns>The maximum element found.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the collection is empty.</exception>
        public static T Max<T>(this IEnumerator<T> enumerator) where T : IComparable<T>
        {
            enumerator.First();
            if (enumerator.End())
            {
                throw new InvalidOperationException("Cannot find maximum: the collection is empty.");
            }

            // Assume the first element is the max
            T max = enumerator.Current();
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

        /// <summary>
        /// Selects the first element that satisfies the given condition, assuming it strictly exists.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="enumerator">The enumerator traversing the collection.</param>
        /// <param name="predicate">The condition the element must satisfy.</param>
        /// <returns>The first element that matches the condition.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the collection is empty or no element matches.</exception>
        public static T Select<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate)
        {
            enumerator.First();

            if (enumerator.End())
            {
                throw new InvalidOperationException("Selection precondition violated: The collection is empty.");
            }

            while (!predicate(enumerator.Current()))
            {
                enumerator.Next();
                if (enumerator.End())
                {
                    throw new InvalidOperationException("There should be at least one element that satisfies the predicate in select");
                }
            }
            return enumerator.Current();
        }

        /// <summary>
        /// Checks if at least one element satisfies the condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="enumerator">The enumerator traversing the collection.</param>
        /// <param name="predicate">The condition to test against.</param>
        /// <returns>True if a matching element is found, false otherwise.</returns>
        public static bool Any<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate)
        {
            enumerator.First();
            while (!enumerator.End())
            {
                if (predicate(enumerator.Current()))
                {
                    // Found a matching element, stop iterating immediately
                    return true;
                }
                enumerator.Next();
            }
            // Reached the end without finding any match
            return false;
        }

        /// <summary>
        /// Tries to find the first element that satisfies the condition without throwing an exception if not found.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="enumerator">The enumerator traversing the collection.</param>
        /// <param name="predicate">The condition to test against.</param>
        /// <param name="result">The variable to store the found element, or default if not found.</param>
        /// <returns>True if a match is found, false otherwise.</returns>
        public static bool TryFind<T>(this IEnumerator<T> enumerator, Func<T, bool> predicate, out T? result)
        {
            bool l = false;
            enumerator.First();
            T? elem = default;

            while (!l && !enumerator.End())
            {
                if (predicate(enumerator.Current()))
                {
                    l = true;
                    elem = enumerator.Current();
                }
                enumerator.Next();
            }

            result = elem;
            return l;
        }

        /// <summary>
        /// Finds the maximum element that satisfies a given condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <typeparam name="TResult">The type of the evaluated value to compare.</typeparam>
        /// <param name="enumerator">The enumerator traversing the collection.</param>
        /// <param name="f">The function to evaluate elements for comparison.</param>
        /// <param name="predicate">The condition that elements must satisfy to be considered.</param>
        /// <param name="max">Outputs the maximum evaluated value found, or default.</param>
        /// <param name="elem">Outputs the element corresponding to the maximum value, or default.</param>
        /// <returns>True if at least one element satisfied the condition, false otherwise.</returns>
        public static bool Max<T, TResult>(this IEnumerator<T> enumerator,
            Func<T, TResult> f, Func<T, bool> predicate, out TResult? max, out T? elem)
            where TResult : IComparable<TResult>
        {
            bool l = false;
            enumerator.First();
            max = default;
            elem = default;

            while (!enumerator.End())
            {
                if (!predicate(enumerator.Current()))
                {
                    // Do nothing
                }
                else if (predicate(enumerator.Current()) && l)
                {
                    TResult currentVal = f(enumerator.Current());
                    if (currentVal.CompareTo(max) > 0)
                    {
                        max = currentVal;
                        elem = enumerator.Current();
                    }
                }
                else if (predicate(enumerator.Current()) && !l)
                {
                    l = true;
                    max = f(enumerator.Current());
                    elem = enumerator.Current();
                }
                enumerator.Next();
            }
            return l;
        }
    }
}