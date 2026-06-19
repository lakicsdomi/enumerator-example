namespace Enumerators
{
    public class FileEnumerator : IEnumerator<string>, IDisposable
    {
        private enum EStatus
        {
            NORM, ABNORM
        }

        private StreamReader x;  // Stream reader for the file
        private string? e; // Buffer for the current line
        private EStatus st; // Status of the enumerator (normal or abnormal) will be abnormal on EOF

        public FileEnumerator(string filename)
        {
            x = new StreamReader(filename);
            st = EStatus.NORM;
        }

        public void First()
        {
            x.BaseStream.Seek(0, SeekOrigin.Begin); // Go to the beginning of the file
            e = x.ReadLine(); // Read the first line
            st = e == null ? EStatus.ABNORM : EStatus.NORM; // Set status to normal or abnormal if empty
        }

        public void Next()
        {
            if (st == EStatus.NORM)
            {
                e = x.ReadLine(); // Read the next line
                if (e == null) // If we reached EOF
                    st = EStatus.ABNORM; // Set status to abnormal
            }
        }

        public bool End()
        {
            return st == EStatus.ABNORM; // Return true if we are at EOF
        }

        public string Current()
        {
            return e ?? string.Empty; // Return the current line (safe null return)
        }

        // Dispose method to close the file stream
        public void Dispose()
        {
            x?.Dispose();
        }
    }
}