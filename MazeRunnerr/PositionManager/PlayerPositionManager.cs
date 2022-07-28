using MazeRunnerr.EnemyObject;
using MazeRunnerr.Enums;
using MazeRunnerr.GameCoins;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.PositionManager
{
    public class PlayerPositionManager : IPlayerPositionManager
    {
        public IPlayer Player { get; set; }
        public List<IGameEnemy> GameEnemies { get; set; }
        public List<IGameWall> GameWalls { get; set; }
        public List<IGameCoin> GameCoins { get; set; }
        public Direction Key { get; set; }
        public Direction EnemyKey { get; set; }
        public int Size { get; set; }

        public PlayerPositionManager(IPlayer player, List<IGameEnemy> gameEnemies, List<IGameWall> gameWalls, List<IGameCoin> gameCoins, int size)
        {
            this.Player = player;
            this.GameEnemies = gameEnemies;
            this.GameWalls = gameWalls;
            this.GameCoins = gameCoins;
            this.Size = size;
        }

        public bool CheckPlayerWallPosition()
        {
            int playerX = Player.X;
            int playerY = Player.Y;

            foreach (var gameWall in GameWalls)
            {
                int gameWallX = gameWall.X;
                int gameWallY = gameWall.Y;
                if ((Key == Direction.DownArrow && playerY + 1 == Size - 1) || (gameWallY == playerY + 1 && gameWallX == playerX && Key == Direction.DownArrow))
                {
                    return false;
                }
                else if ((Key == Direction.UpArrow && playerY - 1 == 0) || (gameWallY == playerY - 1 && gameWallX == playerX && Key == Direction.UpArrow))
                {
                    return false;
                }
                else if ((Key == Direction.RightArrow && playerX + 1 == Size - 1) || (gameWallX == playerX + 1 && gameWallY == playerY && Key == Direction.RightArrow))
                {
                    return false;
                }
                else if ((Key == Direction.LeftArrow && playerX - 1 == 0) || (gameWallX == playerX - 1 && gameWallY == playerY && Key == Direction.LeftArrow))
                {
                    return false;
                }
            }
            return true;
        }

        public IGameCoin GetPlayerCoinPosition()
        {
            int playerX = Player.X;
            int playerY = Player.Y;

            foreach (var gameCoin in GameCoins)
            {
                int gameCoinX = gameCoin.X;
                int gameCoinY = gameCoin.Y;
                if (gameCoinX == playerX && gameCoinY == playerY)
                {
                    return gameCoin;
                }
            }
            return null;
        }

        public bool CheckPlayerEnemyPosition()
        {
            int playerX = Player.X;
            int playerY = Player.Y;

            foreach (var gameEnemy in GameEnemies)
            {
                int enemyX = gameEnemy.X;
                int enemyY = gameEnemy.Y;
                if (playerY + 1 == enemyY && playerX == enemyX && Key == Direction.DownArrow)
                {
                    return false;
                }
                else if (playerY - 1 == enemyY && playerX == enemyX && Key == Direction.UpArrow)
                {
                    return false;
                }
                else if (playerX + 1 == enemyX && playerY == enemyY && Key == Direction.RightArrow)
                {
                    return false;
                }
                else if (playerX - 1 == enemyX && playerY == enemyY && Key == Direction.LeftArrow)
                {
                    return false;
                }
            }
            return true;
        }

        public bool FinalPlayerEnemyCheck()
        {
            int playerX = Player.X;
            int playerY = Player.Y;

            foreach (var gameEnemy in GameEnemies)
            {
                int enemyX = gameEnemy.X;
                int enemyY = gameEnemy.Y;
                if (playerY == enemyY && playerX == enemyX)
                {
                    return false;
                }
                else if (playerY == enemyY && playerX == enemyX)
                {
                    return false;
                }
                else if (playerX == enemyX && playerY == enemyY)
                {
                    return false;
                }
                else if (playerX == enemyX && playerY == enemyY)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
