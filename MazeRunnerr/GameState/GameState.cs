using MazeRunnerr.EnemyObject;
using MazeRunnerr.GameCoins;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MazeRunnerr.GameState
{
    public class GameState
    {
        public Human Player { get; set; }
        public List<GameWall> GameWalls { get; set; }
        public List<GameEnemy> GameEnemies { get; set; }
        public List<GameCoin> GameCoins { get; set; }
        public int Size { get; set; }

        public GameState(IPlayer player, List<IGameWall> gameWalls, List<IGameEnemy> gameEnemies, List<IGameCoin> gameCoins, int size)
        {
            this.Player = (Human)player;
            this.GameWalls = gameWalls.OfType<GameWall>().ToList();
            this.GameEnemies = gameEnemies.OfType<GameEnemy>().ToList();
            this.GameCoins = gameCoins.OfType<GameCoin>().ToList();
            this.Size = size;
        }

        public GameState()
        {

        }

        public void Serialize()
        {
            string path = @"C:\Users\USER\Desktop\Consoleapp\MazeRunnerr\MazeRunnerr\GameState\GameStore.txt";

            string jsonString = JsonSerializer.Serialize(this);

            File.WriteAllText(path, jsonString);
        }

        public static GameState DeSerialize()
        {
            string path = @"C:\Users\USER\Desktop\Consoleapp\MazeRunnerr\MazeRunnerr\GameState\GameStore.txt";

            string jsonString = File.ReadAllText(path);

            if (String.IsNullOrEmpty(jsonString))
            {
                return null;
            }

            GameState gameState = JsonSerializer.Deserialize<GameState>(jsonString);

            return gameState;
        }
    }
}
