using MazeRunnerr.GameCoins;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class CoinPlayerSpawnManager : ICoinPlayerSpawnManager
    {
        public List<IGameCoin> Coins { get; private set; }
        public IPlayer Player { get; private set; }
        public int Size { get; private set; }

        public CoinPlayerSpawnManager(List<IGameCoin> gameCoins, IPlayer player, int size)
        {
            this.Coins = gameCoins;
            this.Player = player;
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
                if (coin.X == Player.X && coin.Y == Player.Y)
                {
                    return true;
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
