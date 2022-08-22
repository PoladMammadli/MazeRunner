using MazeRunnerr.GameCoins;
using MazeRunnerr.GameWallObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class CoinWallSpawnManager : ICoinWallSpawnManager
    {
        public List<IGameCoin> Coins { get; private set; }
        public List<IGameWall> Walls { get; private set; }
        public int Size { get; private set; }

        public CoinWallSpawnManager(List<IGameCoin> gameCoins, List<IGameWall> gameWalls, int size)
        {
            this.Coins = gameCoins;
            this.Walls = gameWalls;
            this.Size = size;
        }

        public void ChangePosition()
        {
            bool coinSpawnControl = false;
            while (!coinSpawnControl)
            {
                if (CheckSpawn())
                {
                    UpdatePosition();
                    continue;
                }
                coinSpawnControl = true;
            }
        }

        public bool CheckSpawn()
        {
            foreach (var coin in Coins)
            {
                foreach (var wall in Walls)
                {
                    if (coin.X == wall.X && coin.Y == wall.Y)
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
            foreach (var coin in Coins)
            {
                coin.X = random.Next(1, Size - 2);
                coin.Y = random.Next(1, Size - 2);
            }
        }
    }
}
