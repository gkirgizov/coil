using System;

namespace Task2
{
    /// <summary>
    /// Parent exception class for list exceptions
    /// </summary>
    public class ListException : ApplicationException { }

    public class AddExistingItemException : ListException { }

    public class DeleteNonexistentItemException : ListException { }
}
