using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.SetTimer;
using MazeRunner.Wpf.Stores;
using MazeRunner.Wpf.ViewModels;
using MazeRunnerr.EnemyObject;
using MazeRunnerr.GameCoins;
using MazeRunnerr.GameStore;
using MazeRunnerr.GameWallObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace MazeRunner.Wpf.Commands
{
    public class LoadGameCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly GameObject _gameObject;
        public ObservableCollection<ObjectPositionViewModel> Objects = new ObservableCollection<ObjectPositionViewModel>();
        private GameTimer _gameTimer;

        public LoadGameCommand(NavigationStore navigationStore, GameObject gameObject)
        {
            this._navigationStore = navigationStore;
            this._gameObject = gameObject;
        }

        public override bool CanExecute(object parameter)
        {
            GameState gameState = GameState.DeSerialize();

            if (gameState == null)
            {
                return false;
            }

            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            GameState gameState = GameState.DeSerialize();

            if (gameState == null)
            {
                MessageBox.Show("Game not saved.");
                return;
            }

            int gameSize = gameState.Size;

            _gameObject.playerSpawn = gameState.Player;
            _gameObject.gameWalls = gameState.GameWalls.OfType<IGameWall>().ToList();
            _gameObject.gameCoins = gameState.GameCoins.OfType<IGameCoin>().ToList();
            _gameObject.gameEnemies = gameState.GameEnemies.OfType<IGameEnemy>().ToList();
            _gameObject.size = gameSize;

            var updatedObjects = _gameObject.GetUpdatableObjects();

            Objects.Clear();

            foreach(var updatedObject in updatedObjects)
            {
                Objects.Add(updatedObject);
            }

            _gameTimer = new GameTimer(_gameObject, Objects);
            _gameTimer.SetPlayTimer();
            _gameTimer.SetUpdateTimer();

            _navigationStore.CurrentViewModel = new GameAreaViewModel(_gameObject, Objects, _navigationStore, _gameObject.playerSpawn.Point, gameSize);
        }
    }
}
