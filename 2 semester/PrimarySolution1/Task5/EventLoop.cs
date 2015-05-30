using System;
using System.Collections.Generic;

namespace Task5
{
    class ArrowEventLoop
    {
        public event EventHandler<EventArgs> Initialize = (sender, args) => { };

        public event EventHandler<EventArgs> LeftArrowHandler = (sender, args) => { };
        public event EventHandler<EventArgs> RightArrowHandler = (sender, args) => { };
        public event EventHandler<EventArgs> UpArrowHandler = (sender, args) => { };
        public event EventHandler<EventArgs> DownArrowHandler = (sender, args) => { };

        /// <summary>
        /// Starts event waiting
        /// </summary>
        public void Run()
        {
            Initialize(this, EventArgs.Empty);
            while (true)
            {
                var pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftArrowHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        RightArrowHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.UpArrow:
                        UpArrowHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        DownArrowHandler(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}
