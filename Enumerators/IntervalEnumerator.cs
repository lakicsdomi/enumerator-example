namespace Enumerators
{
    public class IntervalEnumerator : IEnumerator<int>
    {
        private int i;  // Current index in the interval
        private int m, n; // m is the start of the interval, n is the end of the interval

        public IntervalEnumerator(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.i = m; // Initialize to one less than the start
        }

        public void First()
        {
            i = m; // Set to the start of the interval
        }

        public void Next()
        {
            i++; // Move to the next index
        }

        public bool End()
        {
            return i > n; // Check if we have passed the end of the interval
        }

        public int Current()
        {
            return i; // Return the current index
        }
    }
}