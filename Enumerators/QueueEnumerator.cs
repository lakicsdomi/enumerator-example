using System.Collections.Generic;

namespace Enumerators
{
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        private T[] elements;
        private int i;
        private int n;

        public QueueEnumerator(Queue<T> queue)
        {
            // Queue.ToArray() returns elements in FIFO order (front to back)
            this.elements = queue.ToArray();
            this.i = -1;
            this.n = elements.Length;
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
            return elements[i];
        }
    }
}