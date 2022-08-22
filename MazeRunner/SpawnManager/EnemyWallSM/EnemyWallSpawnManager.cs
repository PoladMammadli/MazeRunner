using MazeRunnerr.EnemyObject;
using MazeRunnerr.GameWallObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class EnemyWallSpawnManager : IEnemyWallSpawnManager
    {
        public List<IGameEnemy> Enemies { get; private set; }
        public List<IGameWall> Walls { get; private set; }
        public int Size { get; private set; }

        public EnemyWallSpawnManager(List<IGameEnemy> gameEnemies, List<IGameWall> gameWalls, int size)
        {
            this.Enemies = gameEnemies;
            this.Walls = gameWalls;
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
                foreach (var wall in Walls)
                {
                    if (enemy.X == wall.X && enemy.Y == wall.Y)
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
