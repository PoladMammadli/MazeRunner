using MazeRunnerr.EnemyObject;
using MazeRunnerr.Enums;
using MazeRunnerr.GameCoins;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.PositionManager
{
    public interface IPlayerPositionManager : IPositionManager
    {
        Direction PlayerKey { get; set; }
        bool CheckPlayerWallContact();
        bool CheckPlayerEnemyContact();
        bool FinalCheckPlayerEnemyContact();
        IGameCoin GetRemovableCoin();
    }
}
