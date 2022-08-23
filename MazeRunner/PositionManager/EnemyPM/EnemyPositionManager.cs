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
    public class EnemyPositionManager : IEnemyPositionManager
    {
        public List<IGameWall> GameWalls { get; private set; }
        public List<IGameEnemy> GameEnemies { get; private set; }
        public List<IGameCoin> GameCoins { get; private set; }
        public IPlayer Player { get; private set; }
        public Direction EnemyDirection { get; private set; }
        public int Size { get; private set; }

        public EnemyPositionManager(IPlayer player, List<IGameWall> gameWalls, List<IGameEnemy> gameEnemies, List<IGameCoin> gameCoins, int size)
        {
            this.Player = player;
            this.GameWalls = gameWalls;
            this.GameEnemies = gameEnemies;
            this.GameCoins = gameCoins;
            this.Size = size;
        }
        public bool CheckEnemyWallContact(IGameEnemy gameEnemy)
        {
            int gameEnemyX = gameEnemy.X;
            int gameEnemyY = gameEnemy.Y;
            foreach (var gameWall in GameWalls)
            {
                int gameWallX = gameWall.X;
                int gameWallY = gameWall.Y;
                if ((gameEnemy.Direction == Direction.DownArrow && gameEnemyY + 1 == Size - 1) || (gameWallY == gameEnemyY + 1 && gameWallX == gameEnemyX && gameEnemy.Direction == Direction.DownArrow))
                {
                    return false;
                }
                else if ((gameEnemy.Direction == Direction.UpArrow && gameEnemyY - 1 == 0) || (gameWallY == gameEnemyY - 1 && gameWallX == gameEnemyX && gameEnemy.Direction == Direction.UpArrow))
                {
                    return false;
                }
                else if ((gameEnemy.Direction == Direction.RightArrow && gameEnemyX + 1 == Size - 1) || (gameWallX == gameEnemyX + 1 && gameWallY == gameEnemyY && gameEnemy.Direction == Direction.RightArrow))
                {
                    return false;
                }
                else if ((gameEnemy.Direction == Direction.LeftArrow && gameEnemyX - 1 == 0) || (gameWallX == gameEnemyX - 1 && gameWallY == gameEnemyY && gameEnemy.Direction == Direction.LeftArrow))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEnemyCoinContact(IGameEnemy gameEnemy)
        {
            int gameEnemyX = gameEnemy.X;
            int gameEnemyY = gameEnemy.Y;
            foreach (var gameCoin in GameCoins)
            {
                int gameCoinX = gameCoin.X;
                int gameCoinY = gameCoin.Y;
                if (gameCoinY == gameEnemyY + 1 && gameCoinX == gameEnemyX && gameEnemy.Direction == Direction.DownArrow)
                {
                    return false;
                }
                else if (gameCoinY == gameEnemyY - 1 && gameCoinX == gameEnemyX && gameEnemy.Direction == Direction.UpArrow)
                {
                    return false;
                }
                else if (gameCoinX == gameEnemyX + 1 && gameCoinY == gameEnemyY && gameEnemy.Direction == Direction.RightArrow)
                {
                    return false;
                }
                else if (gameCoinX == gameEnemyX - 1 && gameCoinY == gameEnemyY && gameEnemy.Direction == Direction.LeftArrow)
                {
                    return false;
                }
            }
            return true;
        }

        public bool FinalCheckEnemyEnemyContact(IGameEnemy gameEnemy)
        {
            int enemyX = gameEnemy.X;
            int enemyY = gameEnemy.Y;

            foreach (var gameEnemy2 in GameEnemies)
            {
                int enemy2X = gameEnemy2.X;
                int enemy2Y = gameEnemy2.Y;
                if (enemyY + 1 == enemy2Y - 1 && enemyX == enemy2X && gameEnemy.Direction == Direction.DownArrow && gameEnemy2.Direction == Direction.UpArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyY - 1 == enemy2Y + 1 && enemyX == enemy2X && gameEnemy.Direction == Direction.UpArrow && gameEnemy2.Direction == Direction.DownArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyX + 1 == enemy2X - 1 && enemyY == enemy2Y && gameEnemy.Direction == Direction.RightArrow && gameEnemy2.Direction == Direction.LeftArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyX - 1 == enemy2X + 1 && enemyY == enemy2Y && gameEnemy.Direction == Direction.LeftArrow && gameEnemy2.Direction == Direction.RightArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEnemyEnemyContact(IGameEnemy gameEnemy)
        {
            int enemyX = gameEnemy.X;
            int enemyY = gameEnemy.Y;

            foreach (var gameEnemy2 in GameEnemies)
            {
                int enemy2X = gameEnemy2.X;
                int enemy2Y = gameEnemy2.Y;
                if (enemyY + 1 == enemy2Y && enemyX == enemy2X && gameEnemy.Direction == Direction.DownArrow && gameEnemy2.Direction == Direction.UpArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyY - 1 == enemy2Y && enemyX == enemy2X && gameEnemy.Direction == Direction.UpArrow && gameEnemy2.Direction == Direction.DownArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyX + 1 == enemy2X && enemyY == enemy2Y && gameEnemy.Direction == Direction.RightArrow && gameEnemy2.Direction == Direction.LeftArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyX - 1 == enemy2X && enemyY == enemy2Y && gameEnemy.Direction == Direction.LeftArrow && gameEnemy2.Direction == Direction.RightArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyY + 1 == enemy2Y && enemyX == enemy2X && gameEnemy.Direction == Direction.DownArrow && gameEnemy2.Direction == Direction.RightArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyY + 1 == enemy2Y && enemyX == enemy2X && gameEnemy.Direction == Direction.DownArrow && gameEnemy2.Direction == Direction.LeftArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyY - 1 == enemy2Y && enemyX == enemy2X && gameEnemy.Direction == Direction.UpArrow && gameEnemy2.Direction == Direction.LeftArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyY - 1 == enemy2Y && enemyX == enemy2X && gameEnemy.Direction == Direction.UpArrow && gameEnemy2.Direction == Direction.RightArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyX + 1 == enemy2X && enemyY == enemy2Y && gameEnemy.Direction == Direction.RightArrow && gameEnemy2.Direction == Direction.UpArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyX + 1 == enemy2X && enemyY == enemy2Y && gameEnemy.Direction == Direction.RightArrow && gameEnemy2.Direction == Direction.DownArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyX - 1 == enemy2X && enemyY == enemy2Y && gameEnemy.Direction == Direction.LeftArrow && gameEnemy2.Direction == Direction.UpArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
                else if (enemyX - 1 == enemy2X && enemyY == enemy2Y && gameEnemy.Direction == Direction.LeftArrow && gameEnemy2.Direction == Direction.DownArrow && gameEnemy != gameEnemy2)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEnemyPlayerContact(IGameEnemy gameEnemy)
        {
            int playerX = Player.X;
            int playerY = Player.Y;

            int enemyX = gameEnemy.X;
            int enemyY = gameEnemy.Y;
            if (playerY == enemyY + 1 && playerX == enemyX && gameEnemy.Direction == Direction.DownArrow)
            {
                return false;
            }
            else if (playerY == enemyY - 1 && playerX == enemyX && gameEnemy.Direction == Direction.UpArrow)
            {
                return false;
            }
            else if (playerX == enemyX + 1 && playerY == enemyY && gameEnemy.Direction == Direction.RightArrow)
            {
                return false;
            }
            else if (playerX == enemyX - 1 && playerY == enemyY && gameEnemy.Direction == Direction.LeftArrow)
            {
                return false;
            }
            return true;
        }

        public void DefineEnemyDirection()
        {
            Random random = new Random();
            foreach (var gameEnemy in GameEnemies)
            {
                var enemyDirectionValue = random.Next(0, 4);
                gameEnemy.Direction = (Direction)enemyDirectionValue;
            }
        }

        public Direction UpdateEnemyDirection(List<int> oldDirections, IGameEnemy gameEnemy)
        {
            Random random = new Random();
            int enemyDirectionValue = (int)gameEnemy.Direction;
            oldDirections.Add(enemyDirectionValue);
            while (oldDirections.Contains(enemyDirectionValue))
            {
                enemyDirectionValue = random.Next(0, 4);
            }
            Direction enemyDirection = (Direction)enemyDirectionValue;
            return enemyDirection;
        }

        public void ManageEnemyContacts(ref bool enemyTouchedPlayer)
        {
            DefineEnemyDirection();

            foreach (var gameEnemy in GameEnemies)
            {
                List<int> oldDirections = new List<int>();
                bool checkWE = false;
                bool checkEE = false;
                bool checkCE = false;
                bool checkFEE = false;
                do
                {
                    checkWE = false;
                    checkEE = false;
                    checkCE = false;
                    checkFEE = false;
                    if (!CheckEnemyPlayerContact(gameEnemy))
                    {
                        enemyTouchedPlayer = true;
                    }
                    if (CheckEnemyWallContact(gameEnemy))
                    {
                        checkWE = true;
                    }
                    if (CheckEnemyCoinContact(gameEnemy))
                    {
                        checkCE = true;
                    }
                    if (CheckEnemyEnemyContact(gameEnemy))
                    {
                        checkEE = true;
                    }
                    if (FinalCheckEnemyEnemyContact(gameEnemy))
                    {
                        checkFEE = true;
                    }
                    if (!checkWE || !checkEE || !checkFEE || !checkCE)
                    {
                        gameEnemy.Direction = UpdateEnemyDirection(oldDirections, gameEnemy);
                        EnemyDirection = gameEnemy.Direction;
                    }
                }
                while (!checkWE || !checkEE || !checkFEE || !checkCE);

                gameEnemy.Move(gameEnemy.Direction);
            }

        }
    }
}