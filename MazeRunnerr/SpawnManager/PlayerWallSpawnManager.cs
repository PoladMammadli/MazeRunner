using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.SpawnManager
{
    public class PlayerWallSpawnManager : IPlayerWallSpawnManager
    {
        public List<IGameWall> GameWalls { get; set; }
        public IPlayer Player { get; set; }
        public int Size { get; set; }
        public PlayerWallSpawnManager(IPlayer player, List<IGameWall> gameWalls, int size)
        {
            this.GameWalls = gameWalls;
            this.Size = size;
            this.Player = player;
        }
        public bool CheckSpawn()
        {
            Random random = new Random();
            foreach (var gameWall in GameWalls)
            {
                if (gameWall.X == Player.X && gameWall.Y == Player.Y)
                {
                    gameWall.X = random.Next(1, Size - 2);
                    gameWall.Y = random.Next(1, Size - 2);
                    return true;
                }
            }

            return false;
        }
    }
}
