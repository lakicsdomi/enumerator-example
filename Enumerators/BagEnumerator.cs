namespace Enumerators
{
    public class BagEnumerator<T> : IEnumerator<T>
    {
        private Dictionary<T, int> bag;
        private List<T> keys;
        private int currentKeyIndex;
        private int currentItemCount;

        public BagEnumerator(Dictionary<T, int> bag)
        {
            this.bag = bag;
            this.keys = bag.Keys.ToList();
            this.currentKeyIndex = -1;
            this.currentItemCount = 0;
        }

        public void First()
        {
            currentKeyIndex = 0;
            if (keys.Count > 0)
            {
                currentItemCount = bag[keys[0]]; // Set count for the first element
            }
            else
            {
                currentItemCount = 0; // Handle empty bag
            }
        }

        public void Next()
        {
            if (currentKeyIndex >= keys.Count) return;

            currentItemCount--; // Decrement the count for the current element

            // If we exhausted the current element, move to the next key
            if (currentItemCount <= 0)
            {
                currentKeyIndex++;
                if (currentKeyIndex < keys.Count)
                {
                    currentItemCount = bag[keys[currentKeyIndex]];
                }
            }
        }

        public bool End()
        {
            return currentKeyIndex >= keys.Count; // Check if we have passed the last key
        }

        public T Current()
        {
            return keys[currentKeyIndex]; // Return the current key
        }
    }
}