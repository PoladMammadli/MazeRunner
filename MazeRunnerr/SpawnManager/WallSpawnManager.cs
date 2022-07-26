using MazeRunnerr.GameWallObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class WallSpawnManager : IWallSpawnManager
    {
        public List<IGameWall> GameWalls { get; set; }
        public int Size { get; set; }
        public WallSpawnManager(List<IGameWall> gameWalls, int size)
        {
            this.GameWalls = gameWalls;
            this.Size = size;
        }
        public bool CheckSpawn()
        {
            Random random = new Random();
            for (int i = 0; i < GameWalls.Count; i++)
            {
                for (int j = 0; j < GameWalls.Count; j++)
                {
                    if (GameWalls[i].X == GameWalls[j].X && GameWalls[i].Y == GameWalls[j].Y && i != j)
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
            foreach (var gameWall in GameWalls)
            {
                gameWall.X = random.Next(1, Size - 2);
                gameWall.Y = random.Next(1, Size - 2);
            }
        }
    }
}
