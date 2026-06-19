namespace Enumerators
{
    public class ListEnumerator<T> : IEnumerator<T>
    {
        private List<T> l;
        private int i; // Current index in the list

        public ListEnumerator(List<T> list)
        {
            l = list;
            i = -1; // Initialize to one less than the first index
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
            return i >= l.Count; // Check if we have passed the last index
        }

        public T Current()
        {
            return l[i]; // Return the current element
        }
    }
}