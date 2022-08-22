using MazeRunnerr.GameObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.Player
{
    public interface IPlayer : IMovableObject
    {
        public int Point { get; set; }
    }
}
