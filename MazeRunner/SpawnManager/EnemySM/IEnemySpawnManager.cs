﻿using MazeRunnerr.EnemyObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface IEnemySpawnManager : ISpawnManager
    {
        public List<IGameEnemy> Enemies { get; }
        public int Size { get; }
    }
}
