using System;

namespace ControlWork1
{
    public class QueueException : ApplicationException { }

    public class EmptyQueueException : QueueException { }
}
