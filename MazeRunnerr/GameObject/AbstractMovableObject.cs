using MazeRunnerr.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.GameObject
{
    public abstract class AbstractMovableObject : IMovableObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract ObjectColor Color { get; }

        public void Move(Direction userInput)
        {
            if (userInput == Direction.DownArrow)
            {
                Y++;
            }
            else if (userInput == Direction.UpArrow)
            {
                Y--;
            }
            else if (userInput == Direction.RightArrow)
            {
                X++;
            }
            else if (userInput == Direction.LeftArrow)
            {
                X--;
            }
        }
    }
}
