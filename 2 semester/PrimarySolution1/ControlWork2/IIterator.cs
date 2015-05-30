
namespace ControlWork2
{
    public interface IIterator<T>
    {
        /// <summary>
        /// Returns next item in the data structure
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
