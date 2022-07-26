using MazeRunnerr.EnemyObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class EnemySpawnManager : IEnemySpawnManager
    {
        public List<IGameEnemy> Enemies { get ; set ; }
        public int Size { get; set; }
        public EnemySpawnManager(List<IGameEnemy> enemies, int size)
        {
            this.Enemies = enemies;
            this.Size = size;
        }

        public bool CheckSpawn()
        {
            Random random = new Random();
            for (int i = 0; i < Enemies.Count; i++)
            {
                for (int j = 0; j < Enemies.Count; j++)
                {
                    if (Enemies[i].X == Enemies[j].X && Enemies[i].Y == Enemies[j].Y && i != j)
                    {
                        Enemies[i].X = random.Next(1, Size - 2);
                        Enemies[i].Y = random.Next(1, Size - 2);
                        return true;
                    }
                }
            }            
                    
            return false;
        }
    }
}
