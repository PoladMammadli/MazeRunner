using MazeRunnerr.EnemyObject;
using MazeRunnerr.Enums;
using MazeRunnerr.GameWallObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.PositionManager
{
    public interface IEnemyPositionManager : IPositionManager
    {
        public List<IGameWall> GameWalls { get; set; }
        public IGameEnemy GameEnemy { get; set; }
        public Direction EnemyDirection { get; set; }
        public int Size { get; set; }
        bool CheckEnemyWallPosition();
        bool CheckEnemyPlayerPosition();
    }
}
