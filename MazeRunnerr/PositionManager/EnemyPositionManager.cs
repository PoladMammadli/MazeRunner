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
        public List<IGameEnemy> GameEnemies { get; set; }
        public IPlayer Player { get; set; }
        public Direction EnemyDirection { get; set; }
        public int Size { get; set; }

        public EnemyPositionManager(IPlayer player, List<IGameWall> gameWalls, List<IGameEnemy> gameEnemies, int size)
        {
            this.Player = player;
            this.GameWalls = gameWalls;
            this.GameEnemies = gameEnemies;
            this.Size = size;
        }
        public bool CheckEnemyWallPosition(IGameEnemy gameEnemy)
        {
            int gameEnemyX = gameEnemy.X;
            int gameEnemyY = gameEnemy.Y;
            foreach (var gameWall in GameWalls)
            {
                int gameWallX = gameWall.X;
                int gameWallY = gameWall.Y;
                if ((gameEnemy.Direction == Direction.DownArrow && gameEnemyY + 1 == Size - 1) || (gameWallY == gameEnemyY + 1 && gameWallX == gameEnemyX && gameEnemy.Direction == Direction.DownArrow))
                {
                    Console.WriteLine("there is a wall");
                    Console.ReadLine();
                    return false;
                }
                else if ((gameEnemy.Direction == Direction.UpArrow && gameEnemyY - 1 == 0) || (gameWallY == gameEnemyY - 1 && gameWallX == gameEnemyX && gameEnemy.Direction == Direction.UpArrow))
                {
                    Console.WriteLine("there is a wall");
                    Console.ReadLine();
                    return false;
                }
                else if ((gameEnemy.Direction == Direction.RightArrow && gameEnemyX + 1 == Size - 1) || (gameWallX == gameEnemyX + 1 && gameWallY == gameEnemyY && gameEnemy.Direction == Direction.RightArrow))
                {
                    Console.WriteLine("there is a wall");
                    Console.ReadLine();
                    return false;
                }
                else if ((gameEnemy.Direction == Direction.LeftArrow && gameEnemyX - 1 == 0) || (gameWallX == gameEnemyX - 1 && gameWallY == gameEnemyY && gameEnemy.Direction == Direction.LeftArrow))
                {
                    Console.WriteLine("there is a wall");
                    Console.ReadLine();
                    return false;
                }
            }
            return true;
        }

        public bool FinalCheckEnemyEnemyPosition(IGameEnemy gameEnemy)
        {
            int enemyX = gameEnemy.X;
            int enemyY = gameEnemy.Y;

            foreach (var gameEnemy2 in GameEnemies)
            {
                int enemy2X = gameEnemy2.X;
                int enemy2Y = gameEnemy2.Y;
                if (enemyY + 1 == enemy2Y - 1 && enemyX == enemy2X && gameEnemy.Direction == Direction.DownArrow && gameEnemy2.Direction == Direction.UpArrow && gameEnemy != gameEnemy2)
                {
                    Console.WriteLine($"enemy in the same place");
                    Console.ReadLine();
                    return false;
                }
                else if (enemyY - 1 == enemy2Y + 1 && enemyX == enemy2X && gameEnemy.Direction == Direction.UpArrow && gameEnemy2.Direction == Direction.DownArrow && gameEnemy != gameEnemy2)
                {
                    Console.WriteLine($"enemy in the same place");
                    Console.ReadLine();
                    return false;
                }
                else if (enemyX + 1 == enemy2X - 1 && enemyY == enemy2Y && gameEnemy.Direction == Direction.RightArrow && gameEnemy2.Direction == Direction.LeftArrow && gameEnemy != gameEnemy2)
                {
                    Console.WriteLine($"enemy in the same place");
                    Console.ReadLine();
                    return false;
                }
                else if (enemyX - 1 == enemy2X + 1 && enemyY == enemy2Y && gameEnemy.Direction == Direction.LeftArrow && gameEnemy2.Direction == Direction.RightArrow && gameEnemy != gameEnemy2)
                {
                    Console.WriteLine($"enemy in the same place");
                    Console.ReadLine();
                    return false;
                }
            }
            return true;
        }

        public bool CheckEnemyEnemyPosition(IGameEnemy gameEnemy)
        {
            int enemyX = gameEnemy.X;
            int enemyY = gameEnemy.Y;

            foreach (var gameEnemy2 in GameEnemies)
            {
                int enemy2X = gameEnemy2.X;
                int enemy2Y = gameEnemy2.Y;
                if (enemyY + 1 == enemy2Y  && enemyX == enemy2X && gameEnemy.Direction == Direction.DownArrow && gameEnemy2.Direction == Direction.UpArrow && gameEnemy != gameEnemy2)
                {
                    Console.WriteLine($"there is a enemy in {gameEnemy.Direction}");
                    Console.ReadLine();
                    return false;
                }
                else if (enemyY - 1 == enemy2Y  && enemyX == enemy2X && gameEnemy.Direction == Direction.UpArrow && gameEnemy2.Direction == Direction.DownArrow && gameEnemy != gameEnemy2)
                {
                    Console.WriteLine($"there is a enemy in {gameEnemy.Direction}");
                    Console.ReadLine();
                    return false;
                }
                else if (enemyX + 1 == enemy2X  && enemyY == enemy2Y && gameEnemy.Direction == Direction.RightArrow && gameEnemy2.Direction == Direction.LeftArrow && gameEnemy != gameEnemy2)
                {
                    Console.WriteLine($"there is a enemy in {gameEnemy.Direction}");
                    Console.ReadLine();
                    return false;
                }
                else if (enemyX - 1 == enemy2X  && enemyY == enemy2Y && gameEnemy.Direction == Direction.LeftArrow && gameEnemy2.Direction == Direction.RightArrow && gameEnemy != gameEnemy2)
                {
                    Console.WriteLine($"there is a enemy in {gameEnemy.Direction}");
                    Console.ReadLine();
                    return false;
                }
            }
            return true;
        }

        public bool CheckEnemyPlayerPosition(IGameEnemy gameEnemy)
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

        public Direction DefineEnemyDirection()
        {
            Random random = new Random();
            foreach (var gameEnemy in GameEnemies)
            {
                var enemyDirectionValue = random.Next(0, 4);
                EnemyDirection = (Direction)enemyDirectionValue;
                gameEnemy.Direction = EnemyDirection;
            }
            //GameEnemies[0].Direction = Direction.DownArrow;
            //GameEnemies[1].Direction = Direction.UpArrow;
            return EnemyDirection;
        }

        public void ManageEnemyPositions(ref bool enemyTouchedPlayer)
        {
            Random random = new Random();
            DefineEnemyDirection();

            foreach (var gameEnemy in GameEnemies)
            {
                List<int> oldDirections = new List<int>();
                bool checkedWE = false;
                bool checkedEE = false;
                bool checkedFEE = false;
                while (!checkedWE || !checkedEE || !checkedFEE)
                {
                    checkedWE = false;
                    checkedEE = false;
                    checkedFEE = false;
                    if (!CheckEnemyPlayerPosition(gameEnemy))
                    {
                        enemyTouchedPlayer = true;
                    }
                    if (CheckEnemyWallPosition(gameEnemy))
                    {
                        checkedWE = true;
                    }
                    if (CheckEnemyEnemyPosition(gameEnemy))
                    {
                        checkedEE = true;
                    }
                    if (FinalCheckEnemyEnemyPosition(gameEnemy))
                    {
                        checkedFEE = true;
                    }
                    if(!checkedWE || !checkedEE || !checkedFEE)
                    {
                        int enemyDirectionValue = (int)gameEnemy.Direction;
                        oldDirections.Add(enemyDirectionValue);
                        while (oldDirections.Contains(enemyDirectionValue))
                        {
                            enemyDirectionValue = random.Next(0, 4);
                        }
                        gameEnemy.Direction = (Direction)enemyDirectionValue;
                        EnemyDirection = gameEnemy.Direction;
                    }
                }

                gameEnemy.Move(gameEnemy.Direction);

            }
            
        }
    }
}