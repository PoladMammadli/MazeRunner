using MazeRunnerr.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.GameObject
{
    public interface IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract ObjectColor Color { get; }
    }
}
