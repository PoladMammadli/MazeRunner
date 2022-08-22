using MazeRunnerr.EnemyObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class EnemySpawnManager : IEnemySpawnManager
    {
        public List<IGameEnemy> Enemies { get; private set; }
        public int Size { get; private set; }
        public EnemySpawnManager(List<IGameEnemy> enemies, int size)
        {
            this.Enemies = enemies;
            this.Size = size;
        }

        public bool CheckSpawn()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                for (int j = 0; j < Enemies.Count; j++)
                {
                    if (Enemies[i].X == Enemies[j].X && Enemies[i].Y == Enemies[j].Y && i != j)
                    {
                        return true;
                    }
                }
            }
            return false;
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
