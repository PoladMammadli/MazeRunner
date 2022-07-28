using MazeRunnerr.Enums;
using MazeRunnerr.GameObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.EnemyObject
{
    public interface IGameEnemy : IMovableObject
    {
        Direction Direction { get; set; }
    }
}
