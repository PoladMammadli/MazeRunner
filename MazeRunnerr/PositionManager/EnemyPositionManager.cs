using MazeRunnerr.EnemyObject;
using MazeRunnerr.Enums;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeRunnerr.PositionManager
{
    public class EnemyPositionManager : IEnemyPositionManager
    {
        public List<IGameWall> GameWalls { get; set; }
        public IGameEnemy GameEnemy { get; set; }
        public IPlayer Player { get; set; }
        public Direction EnemyDirection { get; set; }
        public int Size { get; set; }

        public EnemyPositionManager(IPlayer player, List<IGameWall> gameWalls, IGameEnemy gameEnemy, int size)
        {
            this.Player = player;
            this.GameWalls = gameWalls;
            this.GameEnemy = gameEnemy;
            this.Size = size;
        }
        public bool CheckEnemyWallPosition()
        {
            int gameEnemyX = GameEnemy.X;
            int gameEnemyY = GameEnemy.Y;
            foreach (var gameWall in GameWalls)
            {
                int gameWallX = gameWall.X;
                int gameWallY = gameWall.Y;
                if ((EnemyDirection == Direction.DownArrow && gameEnemyY + 1 == Size - 1) || (gameWallY == gameEnemyY + 1 && gameWallX == gameEnemyX && EnemyDirection == Direction.DownArrow))
                {
                    return false;
                }
                else if ((EnemyDirection == Direction.UpArrow && gameEnemyY - 1 == 0) || (gameWallY == gameEnemyY - 1 && gameWallX == gameEnemyX && EnemyDirection == Direction.UpArrow))
                {
                    return false;
                }
                else if ((EnemyDirection == Direction.RightArrow && gameEnemyX + 1 == Size - 1) || (gameWallX == gameEnemyX + 1 && gameWallY == gameEnemyY && EnemyDirection == Direction.RightArrow))
                {
                    return false;
                }
                else if ((EnemyDirection == Direction.LeftArrow && gameEnemyX - 1 == 0) || (gameWallX == gameEnemyX - 1 && gameWallY == gameEnemyY && EnemyDirection == Direction.LeftArrow))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEnemyPlayerPosition()
        {
            int playerX = Player.X;
            int playerY = Player.Y;

            int enemyX = GameEnemy.X;
            int enemyY = GameEnemy.Y;
            if (playerY == enemyY + 1 && playerX == enemyX && EnemyDirection == Direction.DownArrow)
            {
                return false;
            }
            else if (playerY == enemyY - 1 && playerX == enemyX && EnemyDirection == Direction.UpArrow)
            {
                return false;
            }
            else if (playerX == enemyX + 1 && playerY == enemyY && EnemyDirection == Direction.RightArrow)
            {
                return false;
            }
            else if (playerX == enemyX - 1 && playerY == enemyY && EnemyDirection == Direction.LeftArrow)
            {
                return false;
            }
            return true;
        }
    }
}
