using MazeRunnerr.GameCoins;
using MazeRunnerr.GameWallObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface ICoinWallSpawnManager : ISpawnManager
    {
        public List<IGameCoin> Coins { get; }
        public List<IGameWall> Walls { get; }
        public int Size { get; }
    }
}
