using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork1
{
    public class QueuePriority<T>
    {
        public QueuePriority()
        {
            this.Size = 0;
        }

        public QueuePriority(T data, int priority)
        {
            this.tail = new QueuePriorityItem<T>(data, priority);
            this.head = this.tail;
            this.Size = 1;
        }

        public int Size { get; private set; }

        /// <summary>
        /// Add item to prioruty queue
        /// </summary>
        public void Enqueue(T data, int priority)
        {
            var newItem = new QueuePriorityItem<T>(data, priority);

            if (this.head == null)
            {
                this.tail = newItem;
                this.head = this.tail;
            }
            else
            {
                if (this.head.Next == null)
                { 
                    if (priority > this.head.Priority)
                    {
                        newItem.Next = this.tail;
                        this.head = newItem;
                    }
                    else
                    {
                        this.tail = newItem;
                        this.head.Next = this.tail;
                    }
                }
                else
                {
                    var ptr = this.head;
                    while (ptr.Next != this.tail && priority <= ptr.Next.Priority)
                    {
                        ptr = ptr.Next;
                    }
                    newItem.Next = ptr.Next;
                    ptr.Next = newItem;
                }
            }
            ++this.Size;
        }

        /// <summary>
        /// Delete item from priority queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new EmptyQueueException();
            }

            var returned = this.head.Data;
            this.head = this.head.Next;
            --this.Size;
            return returned;
        }

        private QueuePriorityItem<T> head = null;

        private QueuePriorityItem<T> tail = null;

        private class QueuePriorityItem<T>
        {
            public QueuePriorityItem(T data, int priority)
            {
                this.Data = data;
                this.Priority = priority;
            }

            public T Data { get; set; }

            public int Priority { get; set; }

            public QueuePriorityItem<T> Next { get; set; }
        }
    }
}
