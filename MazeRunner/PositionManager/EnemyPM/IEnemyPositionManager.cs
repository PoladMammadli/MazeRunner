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
    public interface IEnemyPositionManager : IPositionManager
    {
        public Direction EnemyDirection { get; }
        bool CheckEnemyWallContact(IGameEnemy gameEnemy);
        bool CheckEnemyPlayerContact(IGameEnemy gameEnemy);
        void ManageEnemyContacts(ref bool enemyTouchedPlayer);
        bool CheckEnemyCoinContact(IGameEnemy gameEnemy);
        bool CheckEnemyEnemyContact(IGameEnemy gameEnemy);
        bool FinalCheckEnemyEnemyContact(IGameEnemy gameEnemy);
        Direction UpdateEnemyDirection(List<int> oldDirections, IGameEnemy gameEnemy);
        void DefineEnemyDirection();
    }
}
