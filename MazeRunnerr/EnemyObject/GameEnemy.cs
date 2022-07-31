using MazeRunnerr.Enums;
using MazeRunnerr.GameObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.EnemyObject
{
    public class GameEnemy : AbstractMovableObject, IGameEnemy
    {
        public override ObjectColor Color => ObjectColor.Yellow;
        public Direction Direction { get ; set ; }
    }
}
