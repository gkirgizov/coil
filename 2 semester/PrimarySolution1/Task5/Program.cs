using System;
using System.Collections.Generic;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new ArrowEventLoop();
            var arrowMover = new ConsoleArrowMover();

            eventLoop.Initialize += arrowMover.Initialize;
            eventLoop.LeftArrowHandler += arrowMover.MoveLeft;
            eventLoop.RightArrowHandler += arrowMover.MoveRight;
            eventLoop.UpArrowHandler += arrowMover.MoveUp;
            eventLoop.DownArrowHandler += arrowMover.MoveDown;

            eventLoop.Run();
        }
    }
}