
namespace hw1 {
    public interface IIterator<T> {
        /// <summary>
        /// Returns current item.
        /// </summary>
        T Current { get; }

        /// <summary>
        /// Returns current item and goes to the next.
        /// </summary>
        /// <returns></returns>
        T Next();

        /// <summary>
        /// Returns true if last call of the Next() returned last item
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Resets iteration
        /// </summary>
        void Reset();

        /// <summary>
        /// Deletes current item and goes to the next item.
        /// Returns True if removing is succesful
        /// </summary>
        bool Remove();
    }
}
