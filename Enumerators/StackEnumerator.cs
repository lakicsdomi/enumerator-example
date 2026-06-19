using System.Collections.Generic;

namespace Enumerators
{
    public class StackEnumerator<T> : IEnumerator<T>
    {
        private T[] elements;
        private int i;
        private int n;

        public StackEnumerator(Stack<T> stack)
        {
            // Stack.ToArray() returns elements in LIFO order (top to bottom)
            this.elements = stack.ToArray();
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