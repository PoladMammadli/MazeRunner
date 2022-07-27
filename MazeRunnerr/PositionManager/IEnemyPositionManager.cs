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
        public List<IGameEnemy> GameEnemies { get; set; }
        public Direction EnemyDirection { get; set; }
        public int Size { get; set; }
        bool CheckEnemyWallPosition(IGameEnemy gameEnemy);
        bool CheckEnemyPlayerPosition(IGameEnemy gameEnemy);
        void ManageEnemyPositions(ref bool enemyTouchedPlayer);
    }
}
