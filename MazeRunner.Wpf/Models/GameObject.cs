using MazeRunner.Wpf.Stores;
using MazeRunner.Wpf.ViewModels;
using MazeRunnerr.EnemyObject;
using MazeRunnerr.Enums;
using MazeRunnerr.GameCoins;
using MazeRunnerr.GameManager;
using MazeRunnerr.GameWallObject;
using MazeRunnerr.Player;
using MazeRunnerr.PositionManager;
using MazeRunnerr.SpawnManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MazeRunner.Wpf.Models
{
    public class GameObject
    {
        public GameObject(NavigationStore navigationStore)
        {
            this._navigationStore = navigationStore;
        }

        private readonly NavigationStore _navigationStore;

        GameManagerr gameManager = new GameManagerr();

        public IPlayer playerSpawn;
        public List<IGameWall> gameWalls;
        public List<IGameEnemy> gameEnemies;
        public List<IGameCoin> gameCoins;
        public Direction PlayerDirection;
        public int size;
        private bool enemyTouchedPlayer;
        
        public DispatcherTimer playTimer;
        public DispatcherTimer updateTimer ;


        public void GenerateGameobjects()
        {
            gameWalls = gameManager.CreateGameWalls(size);

            playerSpawn = gameManager.CreatePlayer();

            gameEnemies = gameManager.CreateTraps(size);

            gameCoins = gameManager.CreateCoins(size);
        }

        public void UpdateObjects(ObservableCollection<ObjectPositionViewModel> objects)
        {
            string colorStr;
            BrushConverter brushConverter = new BrushConverter();
            Brush brush;
            objects.Clear();
            foreach (var gameWall in gameWalls)
            {
                colorStr = gameWall.Color.ToString();
                
                brush = (Brush)brushConverter.ConvertFromString(colorStr);
                WallPositionViewModel objectVM = new WallPositionViewModel { Row = gameWall.Y, Column = gameWall.X, Fill = brush };
                objects.Add(objectVM);
            }
            foreach (var gameEnemy in gameEnemies)
            {
                colorStr = gameEnemy.Color.ToString();
                brush = (Brush)brushConverter.ConvertFromString(colorStr);
                EnemyPositionViewModel objectVM = new EnemyPositionViewModel { Row = gameEnemy.Y, Column = gameEnemy.X, Fill = brush };
                objects.Add(objectVM);
            }
            foreach (var gameCoin in gameCoins)
            {
                colorStr = gameCoin.Color.ToString();
                brush = (Brush)brushConverter.ConvertFromString(colorStr);
                CoinPositionViewModel objectVM = new CoinPositionViewModel { Row = gameCoin.Y, Column = gameCoin.X, Fill = brush };
                objects.Add(objectVM);
            }

            colorStr = playerSpawn.Color.ToString();
            brush = (Brush)brushConverter.ConvertFromString(colorStr);
            objects.Add(new PlayerPositionViewModel { Row = playerSpawn.Y, Column = playerSpawn.X, Fill = brush });
        }
        
        public void Start()
        {
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
                    enemySpawnManager.ChangePosition();
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
        }

        public void Play()
        {
            IPlayerPositionManager playerPositionManager = new PlayerPositionManager(playerSpawn, gameEnemies, gameWalls, gameCoins, size);

            playerPositionManager.PlayerKey = PlayerDirection;

            bool playerTouchedWall = false;
            bool playerTouchedEnemy = false;
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


            if (playerTouchedEnemy && enemyTouchedPlayer)
            {
                playTimer.Stop();
                MessageBox.Show("GameOver");
                updateTimer.Stop();
                _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, this, true, playerSpawn.Point);
                return;
            }

            if (playerTouchedWall && enemyTouchedPlayer)
            {
                playTimer.Stop();
                MessageBox.Show("GameOver");
                updateTimer.Stop();
                _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, this, true, playerSpawn.Point);
                return;
            }

            if (playerCanMove)
            {
                playerSpawn.Move(PlayerDirection);
            }

            var removableCoin = playerPositionManager.GetRemovableCoin();
            if (removableCoin != null)
            {
                gameCoins.Remove(removableCoin);
                playerSpawn.Point++;
            }

            if (!playerPositionManager.FinalCheckPlayerEnemyContact())
            {
                playTimer.Stop();
                MessageBox.Show("GameOver");
                updateTimer.Stop();
                _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, this, true, playerSpawn.Point);
                return;
            }

            if (gameCoins.Count == 0)
            {
                playTimer.Stop();
                MessageBox.Show("Congratz! You Win");
                updateTimer.Stop();
                _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, this, true, playerSpawn.Point);
                return;
            }
        }

        public void MoveOnlyEnemy()
        {
            enemyTouchedPlayer = false;

            IEnemyPositionManager enemyPositionManager = new EnemyPositionManager(playerSpawn, gameWalls, gameEnemies, gameCoins, size);

            enemyPositionManager.ManageEnemyContacts(ref enemyTouchedPlayer);

            if (enemyTouchedPlayer)
            {
                playTimer.Stop();
                MessageBox.Show("GameOver");
                updateTimer.Stop();
                _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, this, true, playerSpawn.Point);
                return;
            }
        }
    }
}
