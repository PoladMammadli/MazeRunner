using MazeRunnerr.GameCoins;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class CoinSpawnManager : ICoinSpawnManager
    {
        public List<IGameCoin> GameCoins { get; private set; }
        public int Size { get; private set; }

        public CoinSpawnManager(List<IGameCoin> gameCoins, int size)
        {
            this.GameCoins = gameCoins;
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
            Random random = new Random();
            for (int i = 0; i < GameCoins.Count; i++)
            {
                for (int j = 0; j < GameCoins.Count; j++)
                {
                    if (GameCoins[i].X == GameCoins[j].X && GameCoins[i].Y == GameCoins[j].Y && i != j)
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
            foreach (var gameCoin in GameCoins)
            {
                gameCoin.X = random.Next(1, Size - 2);
                gameCoin.Y = random.Next(1, Size - 2);
            }
        }
    }
}
