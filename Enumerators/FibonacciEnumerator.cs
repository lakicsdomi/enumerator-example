namespace Enumerators
{
    // Enumerators can also be virtual, meaning they
    // can generate values on the fly rather than
    // iterating over a pre-existing collection with
    // explicit elements.
    public class FibonacciEnumerator : IEnumerator<int>
    {
        private int maxCount;
        private int count;
        private int current;
        private int next;

        public FibonacciEnumerator(int maxCount)
        {
            this.maxCount = maxCount;
        }

        public void First()
        {
            count = 0;
            current = 0; // First Fibonacci number
            next = 1;    // Second Fibonacci number
        }

        public void Next()
        {
            int temp = current + next; // Calculate the next number in the sequence
            current = next;
            next = temp;
            count++;
        }

        public bool End()
        {
            return count >= maxCount; // Stop after generating the specified amount of numbers
        }

        public int Current()
        {
            return current;
        }
    }
}