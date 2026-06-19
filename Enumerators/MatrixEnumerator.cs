namespace Enumerators
{
    public class MatrixEnumerator<T> : IEnumerator<T>
    {
        private T[,] a;
        private int i, j; // Current indices in the matrix
        private bool mode; // True for row-wise, false for column-wise
        private int n, m; // n is the number of rows, m is the number of columns

        public MatrixEnumerator(T[,] a, bool mode = true)
        {
            this.a = a;
            this.n = a.GetLength(0);
            this.m = a.GetLength(1);
            this.mode = mode;
        }

        public void First()
        {
            i = 0;
            j = 0;
        }

        public void Next()
        {
            if (mode)
                NextRowWise();
            else
                NextColWise();
        }

        private void NextColWise()
        {
            if (i < n - 1)
            {
                i++;
            }
            else
            {
                i = 0;
                j++;
            }
        }

        private void NextRowWise()
        {
            if (j < m - 1)
            {
                j++;
            }
            else
            {
                j = 0;
                i++;
            }
        }

        public bool End()
        {
            if (mode)
                return i >= n;
            else
                return j >= m;
        }

        public T Current()
        {
            return a[i, j];
        }
    }
}