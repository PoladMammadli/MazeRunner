using MazeRunnerr.EnemyObject;
using MazeRunnerr.GameWallObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface IEnemyWallSpawnManager : ISpawnManager
    {
        public List<IGameEnemy> Enemies { get; }
        public List<IGameWall> Walls { get; }
        public int Size { get; }
    }
}
