using MazeRunnerr.GameCoins;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface ICoinSpawnManager : ISpawnManager
    {
        public List<IGameCoin> GameCoins { get; }
        public int Size { get; }
    }
}
