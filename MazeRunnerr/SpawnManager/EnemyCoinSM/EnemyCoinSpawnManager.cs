using MazeRunnerr.EnemyObject;
using MazeRunnerr.GameCoins;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class EnemyCoinSpawnManager : IEnemyCoinSpawnManager
    {
        public List<IGameEnemy> Enemies { get; private set; }
        public List<IGameCoin> Coins { get; private set; }
        public int Size { get; private set; }

        public EnemyCoinSpawnManager(List<IGameEnemy> gameEnemies, List<IGameCoin> gameCoins, int size)
        {
            this.Coins = gameCoins;
            this.Enemies = gameEnemies;
            this.Size = size;
        }

        public void ChangePosition()
        {
            bool enemySpawnControl = false;
            while (!enemySpawnControl)
            {
                if (CheckSpawn())
                {
                    UpdatePosition();
                    continue;
                }
                enemySpawnControl = true;
            }
        }

        public bool CheckSpawn()
        {
            foreach (var enemy in Enemies)
            {
                foreach (var coin in Coins)
                {
                    if (enemy.X == coin.X && enemy.Y == coin.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void UpdatePosition()
        {
            Random random = new Random();
            foreach (var enemy in Enemies)
            {
                enemy.X = random.Next(1, Size - 2);
                enemy.Y = random.Next(1, Size - 2);
            }
        }
    }
}
