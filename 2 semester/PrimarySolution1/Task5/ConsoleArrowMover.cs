using System;
using System.Collections.Generic;

namespace Task5
{
    /// <summary>
    /// Contains methods allow to handle with arrows pressing events
    /// </summary>
    public class ConsoleArrowMover
    {
        /// <summary>
        /// Changes console title
        /// </summary>
        public void Initialize(object sender, EventArgs args)
        {
            Console.Title = "Build the world";
        }

        /// <summary>
        /// Move arrow to the left to 1 position if it is possible and leave the trace
        /// </summary>
        public void MoveLeft(object sender, EventArgs args)
        {
            if (Console.CursorLeft > 0)
            {
                --Console.CursorLeft;
                Console.Write('_');
                --Console.CursorLeft;
            }
        }

        /// <summary>
        /// Move arrow to the right to 1 position and leave the trace
        /// </summary>
        public void MoveRight(object sender, EventArgs args)
        {
            if (Console.CursorLeft < Console.BufferWidth - 1)
            {
                Console.Write('_');
            }
        }

        /// <summary>
        /// Move arrow to the top to 1 position if it is possible and leave the trace
        /// </summary>
        public void MoveUp(object sender, EventArgs args)
        {
            if (Console.CursorTop > 0)
            {
                --Console.CursorTop;
            }
        }

        /// <summary>
        /// Move arrow to the bottom to 1 position and leave the trace
        /// </summary>
        public void MoveDown(object sender, EventArgs args)
        {
            //Console.SetCursorPosition(Console.CursorLeft, ++Console.CursorTop);
            ++Console.CursorTop;
        }
    }
}
