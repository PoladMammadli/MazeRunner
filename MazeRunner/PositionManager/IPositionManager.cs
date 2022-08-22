using MazeRunnerr.EnemyObject;
using MazeRunnerr.GameCoins;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.PositionManager
{
    public interface IPositionManager
    {
        public int Size { get; }
        public List<IGameWall> GameWalls { get; }
        public List<IGameEnemy> GameEnemies { get; }
        public List<IGameCoin> GameCoins { get; }
        public IPlayer Player { get; }
    }
}
