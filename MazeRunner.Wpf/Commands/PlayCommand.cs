using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.Stores;
using MazeRunner.Wpf.ViewModels;
using MazeRunnerr.GameStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media;

namespace MazeRunner.Wpf.Commands
{
    public class PlayCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly GameObject _gameObject;

        public PlayCommand(NavigationStore navigationStore, GameObject gameObject)
        {
            this._navigationStore = navigationStore;
            this._gameObject = gameObject;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new NewGameViewModel(_navigationStore, _gameObject);
        }
    }
}
