namespace Enumerators
{
    /// <summary>
    /// A generic enumerator interface that defines the methods for iterating over a collection of type T.
    /// </summary>
    /// <typeparam name="T">
    /// The type of elements in the collection to be enumerated.
    /// </typeparam>
    public interface IEnumerator<T>
    {
        void First();  // Initialize the enumerator to the first element
        void Next();   // Move to the next element
        bool End();    // Check if we have reached the end of the collection
        T Current();   // Get the current element
    }
}