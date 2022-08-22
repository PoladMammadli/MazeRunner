using MazeRunnerr.EnemyObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface IEnemyPlayerSpawnManager : ISpawnManager
    {
        List<IGameEnemy> Enemies { get; }
        IPlayer Player { get; }
        int Size { get; }
    }
}
