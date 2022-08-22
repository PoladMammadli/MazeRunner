using MazeRunner.Wpf.Commands;
using MazeRunner.Wpf.Models;
using MazeRunner.Wpf.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MazeRunner.Wpf.ViewModels
{
    public class NewGameViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly GameObject _gameObject;

        public NewGameViewModel(NavigationStore navigationStore, GameObject gameObject)
        {
            this._navigationStore = navigationStore;
            this._gameObject = gameObject;
            StartCommand = new StartCommand(_navigationStore, _gameObject, this);
        }

        private string _gameSize;
        public string GameSize
        {
            get => _gameSize; 
            set
            {
                _gameSize = value;
                OnPropertyChanged(nameof(GameSize));
            }
        }

        public ICommand StartCommand { get; }

    }
}
