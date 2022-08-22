using MazeRunnerr.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.GameObject
{
    public interface IMovableObject : IGameObject
    {
        public void Move(Direction UserInput);
    }
}
