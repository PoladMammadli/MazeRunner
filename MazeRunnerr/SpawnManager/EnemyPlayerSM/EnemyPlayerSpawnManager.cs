using MazeRunnerr.EnemyObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class EnemyPlayerSpawnManager : IEnemyPlayerSpawnManager
    {
        public List<IGameEnemy> Enemies { get; private set; }
        public IPlayer Player { get; private set; }
        public int Size { get; private set; }

        public EnemyPlayerSpawnManager(List<IGameEnemy> gameEnemies, IPlayer player, int size)
        {
            this.Enemies = gameEnemies;
            this.Player = player;
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
                if (enemy.X == Player.X && enemy.Y == Player.Y)
                {
                    return true;
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
