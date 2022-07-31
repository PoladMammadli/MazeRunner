using MazeRunnerr.GameCoins;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public interface ICoinPlayerSpawnManager : ISpawnManager
    {
        public List<IGameCoin> Coins { get; }
        public IPlayer Player { get; }
        public int Size { get; }

    }
}
