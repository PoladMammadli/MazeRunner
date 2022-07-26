using MazeRunnerr.EnemyObject;
using MazeRunnerr.Enums;
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
        public Direction Key { get; set; }
        public Direction EnemyKey { get; set; }
        public int Size { get; set; }

        public PlayerPositionManager(IPlayer player, List<IGameEnemy> gameEnemies, List<IGameWall> gameWalls, int size)
        {
            this.Player = player;
            this.GameEnemies = gameEnemies;
            this.Size = size;
            this.GameWalls = gameWalls;
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



        //public bool IsValidPosition()
        //{
        //    int playerX = Player.X;
        //    int playerY = Player.Y;
        //    foreach (var gameEnemy in GameEnemies)
        //    {
        //        int gameEnemyX = gameEnemy.X;
        //        int gameEnemyY = gameEnemy.Y;

        //        switch (Key)
        //        {
        //            case Direction.DownArrow:
        //                if (playerY + 1 == gameEnemyY && playerX == gameEnemyX && EnemyKey == Direction.UpArrow)
        //                {
        //                    return false;
        //                }
        //                playerY++;
        //                break;
        //            case Direction.UpArrow:
        //                if (playerY - 1 == gameEnemyY && playerX == gameEnemyX && EnemyKey == Direction.DownArrow)
        //                {
        //                    return false;
        //                }
        //                playerY--;
        //                break;
        //            case Direction.RightArrow:
        //                if (playerX + 1 == gameEnemyX && playerY == gameEnemyY && EnemyKey == Direction.LeftArrow)
        //                {
        //                    return false;
        //                }
        //                playerX++;
        //                break;
        //            case Direction.LeftArrow:
        //                if (playerX - 1 == gameEnemyX && playerY == gameEnemyY && EnemyKey == Direction.RightArrow)
        //                {
        //                    return false;
        //                }
        //                playerX--;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    foreach (var gameEnemy2 in GameEnemies)
        //    {
        //        int gameEnemyX = gameEnemy2.X;
        //        int gameEnemyY = gameEnemy2.Y;

        //        switch (EnemyKey)
        //        {
        //            case Direction.DownArrow:
        //                if (playerY == gameEnemyY + 1 && playerX == gameEnemyX)
        //                {
        //                    return false;
        //                }
        //                break;
        //            case Direction.UpArrow:
        //                if (playerY == gameEnemyY - 1 && playerX == gameEnemyX)
        //                {
        //                    return false;
        //                }
        //                break;
        //            case Direction.RightArrow:
        //                if (playerX == gameEnemyX + 1 && playerY == gameEnemyY)
        //                {
        //                    return false;
        //                }
        //                break;
        //            case Direction.LeftArrow:
        //                if (playerX == gameEnemyX - 1 && playerY == gameEnemyY)
        //                {
        //                    return false;
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    return true;
        //}
    }
}
