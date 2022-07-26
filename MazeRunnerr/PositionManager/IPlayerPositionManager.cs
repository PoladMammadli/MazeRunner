using MazeRunnerr.EnemyObject;
using MazeRunnerr.Enums;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.PositionManager
{
    public interface IPlayerPositionManager : IPositionManager
    {
        public int Size { get; set; }
        IPlayer Player { get; set; }
        List<IGameEnemy> GameEnemies { get; set; }
        List<IGameWall> GameWalls { get; set; }
        Direction Key { get; set; }
        Direction EnemyKey { get; set; }
        bool CheckPlayerWallPosition();

    }
}
