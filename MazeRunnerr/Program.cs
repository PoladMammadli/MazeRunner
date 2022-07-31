using MazeRunnerr.EnemyObject;
using MazeRunnerr.Enums;
using MazeRunnerr.GameObject;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using MazeRunnerr.PositionManager;
using MazeRunnerr.SpawnManager;
using System;
using System.Collections.Generic;
using MazeRunnerr.GameManager;
using MazeRunnerr.GameCoins;
using System.Drawing;

namespace MazeRunnerr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the Maze");
            int size = int.Parse(Console.ReadLine());

            GameManagerr gameManager = new GameManagerr();

            List<IGameWall> gameWalls = gameManager.CreateGameWalls(size);

            IPlayer playerSpawn = gameManager.CreatePlayer();

            List<IGameEnemy> gameEnemies = gameManager.CreateTraps(size);

            List<IGameCoin> gameCoins = gameManager.CreateCoins(size);

            bool checkWall = false;
            bool checkCoin = false;
            bool checkEnemy = false;
            bool checkPlayerWall = false;
            bool checkEnemyPlayer = false;
            bool checkCoinPlayer = false;
            bool checkEnemyWall = false;
            bool checkEnemyCoin = false;
            bool checkCoinWall = false;
            do
            {
                checkWall = false;
                checkCoin = false;
                checkEnemy = false;
                checkPlayerWall = false;
                checkEnemyPlayer = false;
                checkCoinPlayer = false;
                checkEnemyWall = false;
                checkEnemyCoin = false;
                checkCoinWall = false;
                IWallSpawnManager wallSpawnManager = new WallSpawnManager(gameWalls, size);
                if (wallSpawnManager.CheckSpawn())
                {
                    wallSpawnManager.ChangePosition();
                    checkWall = true;
                }

                ICoinSpawnManager coinSpawnManager = new CoinSpawnManager(gameCoins, size);
                if (coinSpawnManager.CheckSpawn())
                {
                    coinSpawnManager.ChangePosition();
                    checkCoin = true;
                }

                IEnemySpawnManager enemySpawnManager = new EnemySpawnManager(gameEnemies, size);
                if (enemySpawnManager.CheckSpawn())
                {
                    enemySpawnManager.ChangePosition(); //
                    checkEnemy = true;
                }

                IPlayerWallSpawnManager playerWallSpawnManager = new PlayerWallSpawnManager(playerSpawn, gameWalls, size);
                if (playerWallSpawnManager.CheckSpawn())
                {
                    playerWallSpawnManager.ChangePosition();
                    checkPlayerWall = true;
                }

                IEnemyPlayerSpawnManager enemyPlayerSpawnManager = new EnemyPlayerSpawnManager(gameEnemies, playerSpawn, size);
                if (enemyPlayerSpawnManager.CheckSpawn())
                {
                    enemyPlayerSpawnManager.ChangePosition();
                    checkEnemyPlayer = true;
                }

                ICoinPlayerSpawnManager coinPlayerSpawnManager = new CoinPlayerSpawnManager(gameCoins, playerSpawn, size);
                if (coinPlayerSpawnManager.CheckSpawn())
                {
                    coinPlayerSpawnManager.ChangePosition();
                    checkCoinPlayer = true;
                }

                IEnemyWallSpawnManager enemyWallSpawnManager = new EnemyWallSpawnManager(gameEnemies, gameWalls, size);
                if (enemyWallSpawnManager.CheckSpawn())
                {
                    enemyWallSpawnManager.ChangePosition();
                    checkEnemyWall = true;
                }

                IEnemyCoinSpawnManager enemyCoinSpawnManager = new EnemyCoinSpawnManager(gameEnemies, gameCoins, size);
                if (enemyCoinSpawnManager.CheckSpawn())
                {
                    enemyCoinSpawnManager.ChangePosition();
                    checkEnemyCoin = true;
                }

                ICoinWallSpawnManager coinWallSpawnManager = new CoinWallSpawnManager(gameCoins, gameWalls, size);
                if (coinWallSpawnManager.CheckSpawn())
                {
                    coinWallSpawnManager.ChangePosition();
                    checkCoinWall = true;
                }
            }
            while (checkWall || checkCoin || checkEnemy || checkPlayerWall || checkEnemyPlayer || checkCoinPlayer || checkEnemyWall || checkEnemyCoin || checkCoinWall);
            ConsoleKey key;

            IPlayerPositionManager playerPositionManager = new PlayerPositionManager(playerSpawn, gameEnemies, gameWalls, gameCoins, size);
            IEnemyPositionManager enemyPositionManager = new EnemyPositionManager(playerSpawn, gameWalls, gameEnemies, gameCoins, size);

            Update(playerSpawn, gameWalls, gameEnemies, gameCoins, size);

            do
            {
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                {
                    continue;
                }
                string playerInput = key.ToString();
                Direction playerDirection;
                try
                {
                    playerDirection = Enum.Parse<Direction>(playerInput);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine();
                    Console.WriteLine("enter valid key");
                    continue;
                }

                playerPositionManager.PlayerKey = playerDirection;
                bool playerTouchedWall = false;
                bool playerTouchedEnemy = false;
                bool enemyTouchedPlayer = false;
                bool playerCanMove = true;

                if (!playerPositionManager.CheckPlayerWallContact())
                {
                    playerTouchedWall = true;
                    playerCanMove = false;
                }

                if (!playerPositionManager.CheckPlayerEnemyContact())
                {
                    playerTouchedEnemy = true;
                }

                enemyPositionManager.ManageEnemyContacts(ref enemyTouchedPlayer);

                if (playerTouchedEnemy && enemyTouchedPlayer)
                {
                    Console.WriteLine("Game Over 1");
                    Console.ReadLine();
                }

                if (playerTouchedWall && enemyTouchedPlayer)
                {
                    Console.WriteLine("Game Over 2");
                    Console.ReadLine();
                }

                if (playerCanMove)
                {
                    playerSpawn.Move(playerDirection);
                }

                var removeCoin = playerPositionManager.GetRemovableCoin();
                if (removeCoin != null)
                {
                    gameCoins.Remove(removeCoin);
                    playerSpawn.Point++;
                }

                if (!playerPositionManager.FinalCheckPlayerEnemyContact())
                {
                    Console.WriteLine("Game Over 3");
                    Console.ReadLine();
                }

                Update(playerSpawn, gameWalls, gameEnemies, gameCoins, size);
                if (gameCoins.Count == 0)
                {
                    Console.WriteLine("Congrats! You Win");
                    Console.ReadLine();
                }
            } while (key != ConsoleKey.Escape);
        }


        public static void Update(IPlayer player, List<IGameWall> gameWalls, List<IGameEnemy> gameEnemies, List<IGameCoin> gameCoins, int size)
        {
            Console.Clear();

            bool checkWall = false;
            bool checkWE = false;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    foreach (var gameWall in gameWalls)
                    {
                        if (j == gameWall.X && i == gameWall.Y)
                        {
                            string gameWallStr = gameWall.Color.ToString();
                            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), gameWallStr);
                            Console.ForegroundColor = color;
                            Console.Write("# ");
                            Console.ForegroundColor = ConsoleColor.White;
                            checkWall = true;
                            checkWE = true;
                            break;
                        }
                    }
                    foreach (var gameCoin in gameCoins)
                    {
                        if (j == gameCoin.X && i == gameCoin.Y)
                        {
                            string gameCoinStr = gameCoin.Color.ToString();
                            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), gameCoinStr);
                            Console.ForegroundColor = color;
                            Console.Write("$ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            checkWall = true;
                            checkWE = true;
                            break;
                        }
                    }
                    if (!checkWE)
                    {
                        foreach (var gameEnemy in gameEnemies)
                        {
                            if (j == gameEnemy.X && i == gameEnemy.Y)
                            {
                                string gameEnemyStr = gameEnemy.Color.ToString();
                                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), gameEnemyStr);
                                Console.ForegroundColor = color;
                                Console.Write("* ");
                                Console.ForegroundColor = ConsoleColor.White;
                                checkWall = true;
                                break;
                            }
                        }
                    }

                    if (!checkWall)
                    {
                        if (i == 0 || j == 0 || i == size - 1 || j == size - 1)
                        {
                            Console.Write("# ");
                            continue;
                        }
                        else if (j == player.X && i == player.Y)
                        {
                            string gamePlayerStr = player.Color.ToString();
                            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), gamePlayerStr);
                            Console.ForegroundColor = color;
                            Console.Write("@ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        else
                        {
                            Console.Write("  ");
                            continue;
                        }
                    }
                    checkWall = false;
                    checkWE = false;
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Point {player.Point}/{size / 2}");
        }
    }
}
