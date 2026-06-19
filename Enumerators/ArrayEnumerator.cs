namespace Enumerators
{
    public class ArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] array;
        private int i;
        private int n;

        public ArrayEnumerator(T[] array)
        {
            this.array = array;
            this.i = -1;
            this.n = array.Length;
        }

        public void First()
        {
            i = 0;
        }

        public void Next()
        {
            i++;
        }

        public bool End()
        {
            return i >= n;
        }

        public T Current()
        {
            return array[i];
        }
    }
}