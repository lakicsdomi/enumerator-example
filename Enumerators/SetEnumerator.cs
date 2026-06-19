using System.Collections.Generic;
using System.Linq;

namespace Enumerators
{
    public class SetEnumerator<T> : IEnumerator<T>
    {
        private T[] elements;
        private int i; // Current index
        private int n; // Total number of elements

        public SetEnumerator(HashSet<T> set)
        {
            this.elements = set.ToArray(); // Create a snapshot of the set
            this.i = -1;
            this.n = elements.Length;
        }

        public void First()
        {
            i = 0; // Set to the first index
        }

        public void Next()
        {
            i++; // Move to the next index
        }

        public bool End()
        {
            return i >= n; // Check if we have passed the last index
        }

        public T Current()
        {
            return elements[i]; // Return the current element
        }
    }
}