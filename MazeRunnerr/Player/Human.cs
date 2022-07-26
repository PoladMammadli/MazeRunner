using MazeRunnerr.Enums;
using MazeRunnerr.GameObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.Player
{
    public class Human : AbstractMovableObject, IPlayer
    {
        public override ObjectColor Color => ObjectColor.Green;
    }
}
