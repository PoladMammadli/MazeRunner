using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.Stores;
using MazeRunner.Wpf.ViewModels;
using MazeRunnerr.GameStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MazeRunner.Wpf.Commands
{
    public class SaveGameCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly GameObject _gameObject;

        public SaveGameCommand(NavigationStore navigationStore, GameObject gameObject)
        {
            this._navigationStore = navigationStore;
            this._gameObject = gameObject;
        }

        public override void Execute(object parameter)
        {
            GameState gameState = new GameState(_gameObject.playerSpawn, _gameObject.gameWalls, _gameObject.gameEnemies, _gameObject.gameCoins, _gameObject.size);
            gameState.Serialize();
            _gameObject.playTimer.Stop();
            _gameObject.updateTimer.Stop();
            MessageBox.Show("Game Saved");

            _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, _gameObject, false, 0);
        }
    }
}
