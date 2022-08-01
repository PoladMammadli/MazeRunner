using MazeRunnerr.EnemyObject;
using MazeRunnerr.GameCoins;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.GameManager
{
    public class GameManagerr
    {
        public Random Random = new Random();

        public List<IGameWall> CreateGameWalls(int size)
        {
            int wallCount = size / 2;
            List<IGameWall> gameWalls = new List<IGameWall>();
            for (int i = 0; i < wallCount; i++)
            {
                GameWall gameWall = new GameWall { X = Random.Next(1, size - 2), Y = Random.Next(1, size - 2) };
                gameWalls.Add(gameWall);
            }
            return gameWalls;
        }

        public IPlayer CreatePlayer()
        {
            IPlayer playerSpawn = new Human { X = 3, Y = 2 };
            return playerSpawn;
        }

        public List<IGameEnemy> CreateTraps(int size)
        {
            int enemyCount = size / 3;
            List<IGameEnemy> gameEnemies = new List<IGameEnemy>();
            for (int i = 0; i < enemyCount; i++)
            {
                GameEnemy gameEnemy = new GameEnemy { X = Random.Next(1, size - 2), Y = Random.Next(1, size - 2) };
                gameEnemies.Add(gameEnemy);
            }
            return gameEnemies;
        }

        public List<IGameCoin> CreateCoins(int size)
        {
            int coinCount = size / 2;
            List<IGameCoin> gameCoins = new List<IGameCoin>();
            for (int i = 0; i < coinCount; i++)
            {
                GameCoin gameCoin = new GameCoin { X = Random.Next(1, size - 2), Y = Random.Next(1, size - 2) };
                gameCoins.Add(gameCoin);
            }
            return gameCoins;
        }
    }
}
