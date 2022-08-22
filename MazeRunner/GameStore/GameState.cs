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

namespace MazeRunnerr.GameStore
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

        public static bool CheckFolderExists(ref string path)
        {
            path = Path.Combine(path, "MazeRunner");

            if (!Directory.Exists(path))
            {
                return false;
            }
            return true;
        }

        public static bool CheckFileExists(ref string path)
        {
            path = Path.Combine(path, "GameStore.txt");

            if (!File.Exists(path))
            {
                return false;
            }
            return true;
        }

        public void Serialize()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (!CheckFolderExists(ref path))
            {
                Directory.CreateDirectory(path);
            }

            if (!CheckFileExists(ref path))
            {
                File.CreateText(path);
            }
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(path, jsonString);
        }

        public static GameState DeSerialize()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (!CheckFolderExists(ref path))
            {
                Directory.CreateDirectory(path);
            }

            if (!CheckFileExists(ref path))
            {
                File.CreateText(path);
            }
            else
            {
                string jsonString = File.ReadAllText(path);

                if (String.IsNullOrEmpty(jsonString))
                {
                    return null;
                }

                GameState gameState = JsonSerializer.Deserialize<GameState>(jsonString);

                return gameState;
            }
            return null;
        }

        public static void Clear()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            path = Path.Combine(path, "MazeRunner", "GameStore.txt");

            string jsonString = File.ReadAllText(path);

            if (!String.IsNullOrEmpty(jsonString))
            {
                File.WriteAllText(path, String.Empty);
            }
        }
    }
}
