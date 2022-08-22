using MazeRunnerr.EnemyObject;
using MazeRunnerr.GameCoins;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface IEnemyCoinSpawnManager : ISpawnManager
    {
        public List<IGameEnemy> Enemies { get; }
        public List<IGameCoin> Coins { get; }
        public int Size { get; }
    }
}
