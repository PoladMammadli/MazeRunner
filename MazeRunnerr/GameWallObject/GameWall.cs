using MazeRunnerr.Enums;
using MazeRunnerr.GameObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.GameWallObject
{
    public class GameWall : IGameWall
    {
        public int X { get ; set ; }
        public int Y { get ; set ; }
        public ObjectColor Color => ObjectColor.Red;
    }
}
