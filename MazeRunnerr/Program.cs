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

namespace MazeRunnerr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the size of the Maze");
            int size = int.Parse(Console.ReadLine());

            Random random = new Random();

            GameManagerr gameManager = new GameManagerr();

            List<IGameWall> gameWalls = gameManager.CreateGameWalls(size);

            IPlayer playerSpawn = gameManager.CreatePlayer();

            List<IGameEnemy> gameEnemies = gameManager.CreateTraps(size);

            List<IGameCoin> gameCoins = gameManager.CreateCoins(size);

            IWallSpawnManager wallSpawnManager = new WallSpawnManager(gameWalls, size);
            wallSpawnManager.ChangePosition();

            ICoinSpawnManager coinSpawnManager = new CoinSpawnManager(gameCoins, size);
            coinSpawnManager.ChangePosition();

            IEnemySpawnManager spawnManager = new EnemySpawnManager(gameEnemies, size);
            spawnManager.ChangePosition(); //

            IPlayerWallSpawnManager playerWallSpawnManager = new PlayerWallSpawnManager(playerSpawn, gameWalls, size);
            playerWallSpawnManager.ChangePosition();

            ConsoleKey key;
            IPlayerPositionManager playerPositionManager = new PlayerPositionManager(playerSpawn, gameEnemies, gameWalls, size);
            IEnemyPositionManager enemyPositionManager = new EnemyPositionManager(playerSpawn, gameWalls, gameEnemies, size);
            Update(playerSpawn, gameWalls, gameEnemies, gameCoins, size);

            do
            {
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                {
                    continue;
                }
                string playerInput = key.ToString();
                Direction enemyDirection;
                Direction crashedEnemyDirection = default;
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
                
                playerPositionManager.Key = playerDirection;
                bool playerTouchedWall = false;
                bool playerTouchedEnemy = false;
                bool enemyTouchedPlayer = false;
                bool playerCanMove = true;

                if (!playerPositionManager.CheckPlayerWallPosition())
                {
                    playerTouchedWall = true;
                    playerCanMove = false;
                }
                if (!playerPositionManager.CheckPlayerEnemyPosition())
                {
                    playerTouchedEnemy = true;
                }

                enemyPositionManager.ManageEnemyPositions(ref enemyTouchedPlayer);

                if (playerTouchedEnemy && enemyTouchedPlayer)
                {
                    Console.WriteLine("Game Over 1");
                    Console.WriteLine($"Player move {playerDirection} Enemy move {crashedEnemyDirection}");
                    Console.ReadLine();
                }

                if (playerTouchedWall && enemyTouchedPlayer)
                {
                    Console.WriteLine("Game Over 2");
                    Console.WriteLine($"Player move {playerDirection} Enemy move {crashedEnemyDirection}");
                    Console.ReadLine();
                }

                if (playerCanMove)
                {
                    playerSpawn.Move(playerDirection);
                }

                if (!playerPositionManager.FinalPlayerEnemyCheck())
                {
                    Console.WriteLine("Game Over 3");
                    return;
                }

                Update(playerSpawn, gameWalls, gameEnemies, gameCoins, size);
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
        }
    }
}
